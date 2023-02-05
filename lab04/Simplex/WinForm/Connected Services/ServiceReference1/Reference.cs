﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinForm.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="A", Namespace="http://ADA/")]
    [System.SerializableAttribute()]
    public partial class A : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sField;
        
        private int kField;
        
        private float fField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string s {
            get {
                return this.sField;
            }
            set {
                if ((object.ReferenceEquals(this.sField, value) != true)) {
                    this.sField = value;
                    this.RaisePropertyChanged("s");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int k {
            get {
                return this.kField;
            }
            set {
                if ((this.kField.Equals(value) != true)) {
                    this.kField = value;
                    this.RaisePropertyChanged("k");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public float f {
            get {
                return this.fField;
            }
            set {
                if ((this.fField.Equals(value) != true)) {
                    this.fField = value;
                    this.RaisePropertyChanged("f");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ADA/", ConfigurationName="ServiceReference1.SimplexSoap")]
    public interface SimplexSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ADA/Add", ReplyAction="*")]
        int Add(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ADA/Add", ReplyAction="*")]
        System.Threading.Tasks.Task<int> AddAsync(int x, int y);
        
        // CODEGEN: Generating message contract since element name s from namespace http://ADA/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://ADA/Concat", ReplyAction="*")]
        WinForm.ServiceReference1.ConcatResponse Concat(WinForm.ServiceReference1.ConcatRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ADA/Concat", ReplyAction="*")]
        System.Threading.Tasks.Task<WinForm.ServiceReference1.ConcatResponse> ConcatAsync(WinForm.ServiceReference1.ConcatRequest request);
        
        // CODEGEN: Generating message contract since element name a1 from namespace http://ADA/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://ADA/Sum", ReplyAction="*")]
        WinForm.ServiceReference1.SumResponse Sum(WinForm.ServiceReference1.SumRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ADA/Sum", ReplyAction="*")]
        System.Threading.Tasks.Task<WinForm.ServiceReference1.SumResponse> SumAsync(WinForm.ServiceReference1.SumRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ADA/Adds", ReplyAction="*")]
        int Adds(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ADA/Adds", ReplyAction="*")]
        System.Threading.Tasks.Task<int> AddsAsync(int x, int y);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ConcatRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Concat", Namespace="http://ADA/", Order=0)]
        public WinForm.ServiceReference1.ConcatRequestBody Body;
        
        public ConcatRequest() {
        }
        
        public ConcatRequest(WinForm.ServiceReference1.ConcatRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ADA/")]
    public partial class ConcatRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string s;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public double d;
        
        public ConcatRequestBody() {
        }
        
        public ConcatRequestBody(string s, double d) {
            this.s = s;
            this.d = d;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ConcatResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ConcatResponse", Namespace="http://ADA/", Order=0)]
        public WinForm.ServiceReference1.ConcatResponseBody Body;
        
        public ConcatResponse() {
        }
        
        public ConcatResponse(WinForm.ServiceReference1.ConcatResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ADA/")]
    public partial class ConcatResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ConcatResult;
        
        public ConcatResponseBody() {
        }
        
        public ConcatResponseBody(string ConcatResult) {
            this.ConcatResult = ConcatResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SumRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Sum", Namespace="http://ADA/", Order=0)]
        public WinForm.ServiceReference1.SumRequestBody Body;
        
        public SumRequest() {
        }
        
        public SumRequest(WinForm.ServiceReference1.SumRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ADA/")]
    public partial class SumRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WinForm.ServiceReference1.A a1;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public WinForm.ServiceReference1.A a2;
        
        public SumRequestBody() {
        }
        
        public SumRequestBody(WinForm.ServiceReference1.A a1, WinForm.ServiceReference1.A a2) {
            this.a1 = a1;
            this.a2 = a2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SumResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SumResponse", Namespace="http://ADA/", Order=0)]
        public WinForm.ServiceReference1.SumResponseBody Body;
        
        public SumResponse() {
        }
        
        public SumResponse(WinForm.ServiceReference1.SumResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ADA/")]
    public partial class SumResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WinForm.ServiceReference1.A SumResult;
        
        public SumResponseBody() {
        }
        
        public SumResponseBody(WinForm.ServiceReference1.A SumResult) {
            this.SumResult = SumResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SimplexSoapChannel : WinForm.ServiceReference1.SimplexSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SimplexSoapClient : System.ServiceModel.ClientBase<WinForm.ServiceReference1.SimplexSoap>, WinForm.ServiceReference1.SimplexSoap {
        
        public SimplexSoapClient() {
        }
        
        public SimplexSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SimplexSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimplexSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimplexSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(int x, int y) {
            return base.Channel.Add(x, y);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int x, int y) {
            return base.Channel.AddAsync(x, y);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinForm.ServiceReference1.ConcatResponse WinForm.ServiceReference1.SimplexSoap.Concat(WinForm.ServiceReference1.ConcatRequest request) {
            return base.Channel.Concat(request);
        }
        
        public string Concat(string s, double d) {
            WinForm.ServiceReference1.ConcatRequest inValue = new WinForm.ServiceReference1.ConcatRequest();
            inValue.Body = new WinForm.ServiceReference1.ConcatRequestBody();
            inValue.Body.s = s;
            inValue.Body.d = d;
            WinForm.ServiceReference1.ConcatResponse retVal = ((WinForm.ServiceReference1.SimplexSoap)(this)).Concat(inValue);
            return retVal.Body.ConcatResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinForm.ServiceReference1.ConcatResponse> WinForm.ServiceReference1.SimplexSoap.ConcatAsync(WinForm.ServiceReference1.ConcatRequest request) {
            return base.Channel.ConcatAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinForm.ServiceReference1.ConcatResponse> ConcatAsync(string s, double d) {
            WinForm.ServiceReference1.ConcatRequest inValue = new WinForm.ServiceReference1.ConcatRequest();
            inValue.Body = new WinForm.ServiceReference1.ConcatRequestBody();
            inValue.Body.s = s;
            inValue.Body.d = d;
            return ((WinForm.ServiceReference1.SimplexSoap)(this)).ConcatAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinForm.ServiceReference1.SumResponse WinForm.ServiceReference1.SimplexSoap.Sum(WinForm.ServiceReference1.SumRequest request) {
            return base.Channel.Sum(request);
        }
        
        public WinForm.ServiceReference1.A Sum(WinForm.ServiceReference1.A a1, WinForm.ServiceReference1.A a2) {
            WinForm.ServiceReference1.SumRequest inValue = new WinForm.ServiceReference1.SumRequest();
            inValue.Body = new WinForm.ServiceReference1.SumRequestBody();
            inValue.Body.a1 = a1;
            inValue.Body.a2 = a2;
            WinForm.ServiceReference1.SumResponse retVal = ((WinForm.ServiceReference1.SimplexSoap)(this)).Sum(inValue);
            return retVal.Body.SumResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinForm.ServiceReference1.SumResponse> WinForm.ServiceReference1.SimplexSoap.SumAsync(WinForm.ServiceReference1.SumRequest request) {
            return base.Channel.SumAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinForm.ServiceReference1.SumResponse> SumAsync(WinForm.ServiceReference1.A a1, WinForm.ServiceReference1.A a2) {
            WinForm.ServiceReference1.SumRequest inValue = new WinForm.ServiceReference1.SumRequest();
            inValue.Body = new WinForm.ServiceReference1.SumRequestBody();
            inValue.Body.a1 = a1;
            inValue.Body.a2 = a2;
            return ((WinForm.ServiceReference1.SimplexSoap)(this)).SumAsync(inValue);
        }
        
        public int Adds(int x, int y) {
            return base.Channel.Adds(x, y);
        }
        
        public System.Threading.Tasks.Task<int> AddsAsync(int x, int y) {
            return base.Channel.AddsAsync(x, y);
        }
    }
}
