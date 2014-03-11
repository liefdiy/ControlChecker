using System;
using System.Xml;
using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Entity;
using System.Collections;
using System.Collections.Generic;
using Mysoft.Common.Extensions;

namespace Mysoft.Business.Validation
{
    public abstract class AppValidationBase : IAppValidation
    {
        protected AppValidationBase()
        {
            Results = new List<Result>();
        }

        public List<Result> Results { get; protected set; }

        public abstract void Validate(AppControl control);

        public virtual IEnumerable GetResults()
        {
            return Results;
        }

        protected string CreateMsg(string item, string property, string expect, string actual)
        {
            return string.Format("{0}：{1}值无效，期望值：{2}，实际值：{3}", item, property, expect, actual);
        }

        protected void AddResult(string message, Level level)
        {
            if (string.IsNullOrEmpty(message)) return;

            Type type = GetType();
            Results.Add(new Result(type.Name.Replace("Validation", ""), message, level, GetType()));
        }

        protected void AddResult(string item, string property, string expect, string actual, Level level)
        {
            string msg = CreateMsg(item, property, expect, actual);
            AddResult(msg, level);
        }

        public virtual void Dispose()
        {
            
        }

        #region 通用验证方法

        /// <summary>
        /// 验证datetime的time属性
        /// </summary>
        /// <param name="time"></param>
        /// <param name="field"></param>
        protected bool ValidateTime(string time, string field = null)
        {
            bool v = time.Equals("1") || time.Equals("2") || time.Equals("0");
            if (!string.IsNullOrEmpty(field) && v == false)
            {
                AddResult(field, "time", "[0:年－月－日,1:年－月－日　时：分,2:年－月－日　时：分：秒]", time, Level.Error);
            }
            return v;
        }

        /// <summary>
        /// 验证必填项
        /// </summary>
        /// <param name="reqStr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        protected bool ValidateReq(string reqStr, string field = null)
        {
            if (string.IsNullOrEmpty(reqStr)) return true;

            int req = 0;
            if (int.TryParse(reqStr, out req) == false)
            {
                AddResult(field, "req", "[数字类型]", reqStr, Level.Error);                
            }

            bool v = req == 0 || req == 1 || req == 2;
            if (!string.IsNullOrEmpty(field) && v == false)
            {
                AddResult(field, "req", "[0 为非必填，1 为必填，2 为建议填写，默认值为 0]", req.ToString(), Level.Error);
            }
            return v;
        }

        /// <summary>
        /// 验证新增记录时，控件是否可编辑
        /// </summary>
        /// <param name="createapiStr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        protected bool ValidateCreateapi(string createapiStr, string field = null)
        {
            if(string.IsNullOrEmpty(createapiStr))  return true;

            int createapi = 0;
            if (int.TryParse(createapiStr, out createapi) == false)
            {
                AddResult(field, "createapi", "[数字类型]", createapiStr, Level.Error);
            }

            bool v = createapi == 0 || createapi == 1;
            if (!string.IsNullOrEmpty(field) && v == false)
            {
                AddResult(field, "createapi", "[0 为只读，1 为可填，默认值为 1]", createapi.ToString(), Level.Error);
            }
            return v;
        }

        /// <summary>
        /// 验证更新记录时，控件是否可编辑
        /// </summary>
        /// <param name="updateapiStr"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        protected bool ValidateUpdateapi(string updateapiStr, string field = null)
        {
            if (string.IsNullOrEmpty(updateapiStr)) return true;

            int updateapi = 0;
            if (int.TryParse(updateapiStr, out updateapi) == false)
            {
                AddResult(field, "updateapi", "[数字类型]", updateapiStr, Level.Error);
            }

            bool v = updateapi == 0 || updateapi == 1;
            if (!string.IsNullOrEmpty(field) && v == false)
            {
                AddResult(field, "updateapi", "[0 为只读，1 为可填，默认值为 1]", updateapi.ToString(), Level.Error);
            }
            return v;
        }

        /// <summary>
        /// 验证SQL语句是否能正确执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="error"></param>
        /// <returns></returns>
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

        protected void ValidateAttribute(AppControlAttribute attribute, string item = null)
        {
            if (attribute == null) return;

            foreach (XmlAttribute xattr in attribute.Attributes)
            {
                ValidNumber(xattr.Value, "maxlength", item, xattr.Name);
                ValidNumber(xattr.Value, "min", item, xattr.Name);
                ValidNumber(xattr.Value, "max", item, xattr.Name);
                ValidNumber(xattr.Value, "acc", item, xattr.Name);
                ValidBoolean(xattr.Value, "grp", item, xattr.Name);

                //// 以下无需验证
                //string dt = GetAttribute("dt", xattr.Attributes);
                //string forbiddenchars = GetAttribute("forbiddenchars", xattr.Attributes);
            }
        }

        protected void ValidNumber(string str, string property, string item, string name)
        {
            if (name.EqualIgnoreCase(property) == false) return;

            if (str.IsNotNull())
            {
                if (str.IsNumber() == false)
                {
                    AddResult(item ?? "控件属性", property, "[数字类型]", str, Level.Error);
                }
            }
        }

        protected void ValidBoolean(string str, string property, string item, string name)
        {
            if (name.EqualIgnoreCase(property) == false) return;

            if (str.IsNotNull())
            {
                if (str.IsBoolean() == false)
                {
                    AddResult(item ?? "控件属性", property, "[布尔类型]", str, Level.Error);
                }
            }
        }

        #endregion 通用验证方法
    }
}