﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KokoTalk.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Post", Namespace="http://schemas.datacontract.org/2004/07/WCFKokoTalks")]
    [System.SerializableAttribute()]
    public partial class Post : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PostText {
            get {
                return this.PostTextField;
            }
            set {
                if ((object.ReferenceEquals(this.PostTextField, value) != true)) {
                    this.PostTextField = value;
                    this.RaisePropertyChanged("PostText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PostTime {
            get {
                return this.PostTimeField;
            }
            set {
                if ((object.ReferenceEquals(this.PostTimeField, value) != true)) {
                    this.PostTimeField = value;
                    this.RaisePropertyChanged("PostTime");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.KokoService")]
    public interface KokoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/KokoService/GetPost", ReplyAction="http://tempuri.org/KokoService/GetPostResponse")]
        KokoTalk.ServiceReference1.Post[] GetPost(int profiletId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/KokoService/GetPost", ReplyAction="http://tempuri.org/KokoService/GetPostResponse")]
        System.Threading.Tasks.Task<KokoTalk.ServiceReference1.Post[]> GetPostAsync(int profiletId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/KokoService/PushPost", ReplyAction="http://tempuri.org/KokoService/PushPostResponse")]
        void PushPost(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/KokoService/PushPost", ReplyAction="http://tempuri.org/KokoService/PushPostResponse")]
        System.Threading.Tasks.Task PushPostAsync(string query);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface KokoServiceChannel : KokoTalk.ServiceReference1.KokoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KokoServiceClient : System.ServiceModel.ClientBase<KokoTalk.ServiceReference1.KokoService>, KokoTalk.ServiceReference1.KokoService {
        
        public KokoServiceClient() {
        }
        
        public KokoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KokoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KokoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KokoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public KokoTalk.ServiceReference1.Post[] GetPost(int profiletId) {
            return base.Channel.GetPost(profiletId);
        }
        
        public System.Threading.Tasks.Task<KokoTalk.ServiceReference1.Post[]> GetPostAsync(int profiletId) {
            return base.Channel.GetPostAsync(profiletId);
        }
        
        public void PushPost(string query) {
            base.Channel.PushPost(query);
        }
        
        public System.Threading.Tasks.Task PushPostAsync(string query) {
            return base.Channel.PushPostAsync(query);
        }
    }
}
