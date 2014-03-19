using Microsoft.Data.Schema.ScriptDom;
using Microsoft.Data.Schema.ScriptDom.Sql;

namespace Mysoft.Business.Validation
{
    using Mysoft.Business.Controls;
    using Mysoft.Business.Validation.Db;
    using Mysoft.Business.Validation.Entity;
    using Mysoft.Common.Extensions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Xml;

    public abstract class AppValidationBase : IAppValidation
    {
        public List<Result> Results { get; protected set; }

        protected AppValidationBase()
        {
            this.Results = new List<Result>();
        }

        public virtual IEnumerable GetResults()
        {
            return this.Results;
        }

        public abstract void Validate(AppControl control);

        /// <summary>
        /// 验证SDK中定义过的属性
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="item"></param>
        protected void ValidateAttribute(AppControlAttribute attribute, string item = "")
        {
            if (attribute != null)
            {
                foreach (XmlAttribute xattr in attribute.Attributes)
                {
                    ValidNumber(xattr.Value, "maxlength", item, xattr.Name);
                    ValidNumber(xattr.Value, "min", item, xattr.Name);
                    ValidNumber(xattr.Value, "max", item, xattr.Name);
                    ValidNumber(xattr.Value, "acc", item, xattr.Name);
                    ValidBoolean(xattr.Value, "grp", item, xattr.Name);
                }
            }
        }

        /// <summary>
        /// 校验SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected bool IsIncorrectSql(string sql)
        {
            TSql100Parser parser = new TSql100Parser(false);
            IList<ParseError> errors = new List<ParseError>();
            using (StringReader reader = new StringReader(sql))
            {
                parser.Parse(reader, out errors);
                return (errors.Count > 0);
            }
        }

        /// <summary>
        /// 获取SQL中查询出来的全部列名
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected List<string> GetFields(string sql)
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(sql))
            {
                try
                {
                    string temp = CommonValidation.GetFilter(sql);
                    using (SqlConnection connection = new SqlConnection(DbAccessManager.Connectstring))
                    {
                        connection.Open();
                        SqlCommand createCommand = new SqlCommand(temp, connection);
                        using (SqlDataReader sqlReader = createCommand.ExecuteReader())
                        {
                            for (int index = 0; index < sqlReader.FieldCount; index++)
                            {
                                string name = sqlReader.GetName(index);
                                if (!string.IsNullOrEmpty(name))
                                {
                                    list.Add(name);
                                }
                            }
                        }
                    }
                }
                catch (SqlException)
                {
                }
            }
            return list;
        }

        /// <summary>
        /// 验证新增记录时，控件是否可编辑
        /// </summary>
        /// <param name="createapiStr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        protected bool ValidateCreateapi(string createapiStr, string field = "")
        {
            if (string.IsNullOrEmpty(createapiStr))
            {
                return true;
            }
            int createapi = 0;
            if (!int.TryParse(createapiStr, out createapi))
            {
                this.AddResult(field, "createapi", "[数字类型]", createapiStr, Level.Error);
            }
            bool v = (createapi == 0) || (createapi == 1);
            if (!(string.IsNullOrEmpty(field) || v))
            {
                this.AddResult(field, "createapi", "[0 为只读，1 为可填，默认值为 1]", createapi.ToString(), Level.Error);
            }
            return v;
        }

        /// <summary>
        /// 验证必填项
        /// </summary>
        /// <param name="reqStr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        protected bool ValidateReq(string reqStr, string field = "")
        {
            if (string.IsNullOrEmpty(reqStr))
            {
                return true;
            }
            int req = 0;
            if (!int.TryParse(reqStr, out req))
            {
                this.AddResult(field, "req", "[数字类型]", reqStr, Level.Error);
            }
            bool v = ((req == 0) || (req == 1)) || (req == 2);
            if (!(string.IsNullOrEmpty(field) || v))
            {
                this.AddResult(field, "req", "[0 为非必填，1 为必填，2 为建议填写，默认值为 0]", req.ToString(), Level.Error);
            }
            return v;
        }

        protected bool ValidateSql(string sql, out string error)
        {
            error = "";
            string s = CommonValidation.GetFilter(sql);
            try
            {
                CommonValidation.ExecuteSql(s);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return false;
        }

        protected bool ValidateTime(string time, string field = "")
        {
            bool v = (time.Equals("1") || time.Equals("2")) || time.Equals("0");
            if (!(string.IsNullOrEmpty(field) || v))
            {
                this.AddResult(field, "time", "[0:年－月－日,1:年－月－日　时：分,2:年－月－日　时：分：秒]", time, Level.Error);
            }
            return v;
        }

        /// <summary>
        /// 验证更新记录时，控件是否可编辑
        /// </summary>
        /// <param name="updateapiStr"></param>
        /// <param name="field"></param>
        protected bool ValidateUpdateapi(string updateapiStr, string field = "")
        {
            if (string.IsNullOrEmpty(updateapiStr))
            {
                return true;
            }
            int updateapi = 0;
            if (!int.TryParse(updateapiStr, out updateapi))
            {
                this.AddResult(field, "updateapi", "[数字类型]", updateapiStr, Level.Error);
            }
            bool v = (updateapi == 0) || (updateapi == 1);
            if (!(string.IsNullOrEmpty(field) || v))
            {
                this.AddResult(field, "updateapi", "[0 为只读，1 为可填，默认值为 1]", updateapi.ToString(), Level.Error);
            }
            return v;
        }

        protected void ValidBoolean(string str, string property, string item, string name)
        {
            if ((name.EqualIgnoreCase(property) && str.IsNotNull()) && !str.IsBoolean())
            {
                this.AddResult(item ?? "控件属性", property, "[布尔类型]", str, Level.Error);
            }
        }

        protected void ValidNumber(string str, string property, string item, string name)
        {
            if ((name.EqualIgnoreCase(property) && str.IsNotNull()) && !str.IsNumber())
            {
                this.AddResult(item ?? "控件属性", property, "[数字类型]", str, Level.Error);
            }
        }

        protected void AddResult(string message, Level level)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Type type = base.GetType();
                this.Results.Add(new Result(type.Name.Replace("Validation", ""), message, level, base.GetType()));
            }
        }

        protected void AddResult(string item, string property, string expect, string actual, Level level)
        {
            string msg = this.CreateMsg(item, property, expect, actual);
            this.AddResult(msg, level);
        }

        protected string CreateMsg(string item, string property, string expect, string actual)
        {
            return string.Format("{0}：{1}值无效，期望值：{2}，实际值：{3}", item, property, expect, actual);
        }

    }
}