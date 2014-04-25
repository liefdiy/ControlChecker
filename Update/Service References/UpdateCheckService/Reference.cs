﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Update.UpdateCheckService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UpdateCheckService.UpdateCheckSoap")]
    public interface UpdateCheckSoap {
        
        // CODEGEN: 参数“app”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Check", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="app")]
        Update.UpdateCheckService.CheckResponse Check(Update.UpdateCheckService.CheckRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateEntity : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string versionField;
        
        private string updatetimeField;
        
        private string packagepathField;
        
        private System.Xml.XmlNode commentField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
                this.RaisePropertyChanged("version");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string updatetime {
            get {
                return this.updatetimeField;
            }
            set {
                this.updatetimeField = value;
                this.RaisePropertyChanged("updatetime");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string packagepath {
            get {
                return this.packagepathField;
            }
            set {
                this.packagepathField = value;
                this.RaisePropertyChanged("packagepath");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public System.Xml.XmlNode comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
                this.RaisePropertyChanged("comment");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("name");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Check", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CheckRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string appName;
        
        public CheckRequest() {
        }
        
        public CheckRequest(string appName) {
            this.appName = appName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CheckResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CheckResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Update.UpdateCheckService.UpdateEntity app;
        
        public CheckResponse() {
        }
        
        public CheckResponse(Update.UpdateCheckService.UpdateEntity app) {
            this.app = app;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UpdateCheckSoapChannel : Update.UpdateCheckService.UpdateCheckSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpdateCheckSoapClient : System.ServiceModel.ClientBase<Update.UpdateCheckService.UpdateCheckSoap>, Update.UpdateCheckService.UpdateCheckSoap {
        
        public UpdateCheckSoapClient() {
        }
        
        public UpdateCheckSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UpdateCheckSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpdateCheckSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpdateCheckSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Update.UpdateCheckService.CheckResponse Update.UpdateCheckService.UpdateCheckSoap.Check(Update.UpdateCheckService.CheckRequest request) {
            return base.Channel.Check(request);
        }
        
        public Update.UpdateCheckService.UpdateEntity Check(string appName) {
            Update.UpdateCheckService.CheckRequest inValue = new Update.UpdateCheckService.CheckRequest();
            inValue.appName = appName;
            Update.UpdateCheckService.CheckResponse retVal = ((Update.UpdateCheckService.UpdateCheckSoap)(this)).Check(inValue);
            return retVal.app;
        }
    }
}