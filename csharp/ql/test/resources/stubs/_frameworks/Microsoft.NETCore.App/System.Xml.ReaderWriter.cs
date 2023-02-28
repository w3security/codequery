// This file contains auto-generated code.

namespace System
{
    namespace Xml
    {
        // Generated from `System.Xml.ConformanceLevel` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum ConformanceLevel
        {
            Auto,
            Document,
            Fragment,
        }

        // Generated from `System.Xml.DtdProcessing` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum DtdProcessing
        {
            Ignore,
            Parse,
            Prohibit,
        }

        // Generated from `System.Xml.EntityHandling` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum EntityHandling
        {
            ExpandCharEntities,
            ExpandEntities,
        }

        // Generated from `System.Xml.Formatting` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum Formatting
        {
            Indented,
            None,
        }

        // Generated from `System.Xml.IApplicationResourceStreamResolver` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public interface IApplicationResourceStreamResolver
        {
            System.IO.Stream GetApplicationResourceStream(System.Uri relativeUri);
        }

        // Generated from `System.Xml.IHasXmlNode` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public interface IHasXmlNode
        {
            System.Xml.XmlNode GetNode();
        }

        // Generated from `System.Xml.IXmlLineInfo` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public interface IXmlLineInfo
        {
            bool HasLineInfo();
            int LineNumber { get; }
            int LinePosition { get; }
        }

        // Generated from `System.Xml.IXmlNamespaceResolver` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public interface IXmlNamespaceResolver
        {
            System.Collections.Generic.IDictionary<string, string> GetNamespacesInScope(System.Xml.XmlNamespaceScope scope);
            string LookupNamespace(string prefix);
            string LookupPrefix(string namespaceName);
        }

        // Generated from `System.Xml.NameTable` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class NameTable : System.Xml.XmlNameTable
        {
            public override string Add(string key) => throw null;
            public override string Add(System.Char[] key, int start, int len) => throw null;
            public override string Get(string value) => throw null;
            public override string Get(System.Char[] key, int start, int len) => throw null;
            public NameTable() => throw null;
        }

        // Generated from `System.Xml.NamespaceHandling` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        [System.Flags]
        public enum NamespaceHandling
        {
            Default,
            OmitDuplicates,
        }

        // Generated from `System.Xml.NewLineHandling` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum NewLineHandling
        {
            Entitize,
            None,
            Replace,
        }

        // Generated from `System.Xml.ReadState` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum ReadState
        {
            Closed,
            EndOfFile,
            Error,
            Initial,
            Interactive,
        }

        // Generated from `System.Xml.ValidationType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum ValidationType
        {
            Auto,
            DTD,
            None,
            Schema,
            XDR,
        }

        // Generated from `System.Xml.WhitespaceHandling` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum WhitespaceHandling
        {
            All,
            None,
            Significant,
        }

        // Generated from `System.Xml.WriteState` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum WriteState
        {
            Attribute,
            Closed,
            Content,
            Element,
            Error,
            Prolog,
            Start,
        }

        // Generated from `System.Xml.XmlAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlAttribute : System.Xml.XmlNode
        {
            public override System.Xml.XmlNode AppendChild(System.Xml.XmlNode newChild) => throw null;
            public override string BaseURI { get => throw null; }
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string InnerText { set => throw null; }
            public override string InnerXml { set => throw null; }
            public override System.Xml.XmlNode InsertAfter(System.Xml.XmlNode newChild, System.Xml.XmlNode refChild) => throw null;
            public override System.Xml.XmlNode InsertBefore(System.Xml.XmlNode newChild, System.Xml.XmlNode refChild) => throw null;
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override string NamespaceURI { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override System.Xml.XmlDocument OwnerDocument { get => throw null; }
            public virtual System.Xml.XmlElement OwnerElement { get => throw null; }
            public override System.Xml.XmlNode ParentNode { get => throw null; }
            public override string Prefix { get => throw null; set => throw null; }
            public override System.Xml.XmlNode PrependChild(System.Xml.XmlNode newChild) => throw null;
            public override System.Xml.XmlNode RemoveChild(System.Xml.XmlNode oldChild) => throw null;
            public override System.Xml.XmlNode ReplaceChild(System.Xml.XmlNode newChild, System.Xml.XmlNode oldChild) => throw null;
            public override System.Xml.Schema.IXmlSchemaInfo SchemaInfo { get => throw null; }
            public virtual bool Specified { get => throw null; }
            public override string Value { get => throw null; set => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlAttribute(string prefix, string localName, string namespaceURI, System.Xml.XmlDocument doc) => throw null;
        }

        // Generated from `System.Xml.XmlAttributeCollection` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlAttributeCollection : System.Xml.XmlNamedNodeMap, System.Collections.IEnumerable, System.Collections.ICollection
        {
            public System.Xml.XmlAttribute Append(System.Xml.XmlAttribute node) => throw null;
            void System.Collections.ICollection.CopyTo(System.Array array, int index) => throw null;
            public void CopyTo(System.Xml.XmlAttribute[] array, int index) => throw null;
            int System.Collections.ICollection.Count { get => throw null; }
            public System.Xml.XmlAttribute InsertAfter(System.Xml.XmlAttribute newNode, System.Xml.XmlAttribute refNode) => throw null;
            public System.Xml.XmlAttribute InsertBefore(System.Xml.XmlAttribute newNode, System.Xml.XmlAttribute refNode) => throw null;
            bool System.Collections.ICollection.IsSynchronized { get => throw null; }
            [System.Runtime.CompilerServices.IndexerName("ItemOf")]
            public System.Xml.XmlAttribute this[string name] { get => throw null; }
            [System.Runtime.CompilerServices.IndexerName("ItemOf")]
            public System.Xml.XmlAttribute this[string localName, string namespaceURI] { get => throw null; }
            [System.Runtime.CompilerServices.IndexerName("ItemOf")]
            public System.Xml.XmlAttribute this[int i] { get => throw null; }
            public System.Xml.XmlAttribute Prepend(System.Xml.XmlAttribute node) => throw null;
            public System.Xml.XmlAttribute Remove(System.Xml.XmlAttribute node) => throw null;
            public void RemoveAll() => throw null;
            public System.Xml.XmlAttribute RemoveAt(int i) => throw null;
            public override System.Xml.XmlNode SetNamedItem(System.Xml.XmlNode node) => throw null;
            object System.Collections.ICollection.SyncRoot { get => throw null; }
        }

        // Generated from `System.Xml.XmlCDataSection` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlCDataSection : System.Xml.XmlCharacterData
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override System.Xml.XmlNode ParentNode { get => throw null; }
            public override System.Xml.XmlNode PreviousText { get => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlCDataSection(string data, System.Xml.XmlDocument doc) : base(default(string), default(System.Xml.XmlDocument)) => throw null;
        }

        // Generated from `System.Xml.XmlCharacterData` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public abstract class XmlCharacterData : System.Xml.XmlLinkedNode
        {
            public virtual void AppendData(string strData) => throw null;
            public virtual string Data { get => throw null; set => throw null; }
            public virtual void DeleteData(int offset, int count) => throw null;
            public override string InnerText { get => throw null; set => throw null; }
            public virtual void InsertData(int offset, string strData) => throw null;
            public virtual int Length { get => throw null; }
            public virtual void ReplaceData(int offset, int count, string strData) => throw null;
            public virtual string Substring(int offset, int count) => throw null;
            public override string Value { get => throw null; set => throw null; }
            protected internal XmlCharacterData(string data, System.Xml.XmlDocument doc) => throw null;
        }

        // Generated from `System.Xml.XmlComment` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlComment : System.Xml.XmlCharacterData
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlComment(string comment, System.Xml.XmlDocument doc) : base(default(string), default(System.Xml.XmlDocument)) => throw null;
        }

        // Generated from `System.Xml.XmlConvert` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlConvert
        {
            public static string DecodeName(string name) => throw null;
            public static string EncodeLocalName(string name) => throw null;
            public static string EncodeName(string name) => throw null;
            public static string EncodeNmToken(string name) => throw null;
            public static bool IsNCNameChar(System.Char ch) => throw null;
            public static bool IsPublicIdChar(System.Char ch) => throw null;
            public static bool IsStartNCNameChar(System.Char ch) => throw null;
            public static bool IsWhitespaceChar(System.Char ch) => throw null;
            public static bool IsXmlChar(System.Char ch) => throw null;
            public static bool IsXmlSurrogatePair(System.Char lowChar, System.Char highChar) => throw null;
            public static bool ToBoolean(string s) => throw null;
            public static System.Byte ToByte(string s) => throw null;
            public static System.Char ToChar(string s) => throw null;
            public static System.DateTime ToDateTime(string s, string[] formats) => throw null;
            public static System.DateTime ToDateTime(string s, string format) => throw null;
            public static System.DateTime ToDateTime(string s, System.Xml.XmlDateTimeSerializationMode dateTimeOption) => throw null;
            public static System.DateTime ToDateTime(string s) => throw null;
            public static System.DateTimeOffset ToDateTimeOffset(string s, string[] formats) => throw null;
            public static System.DateTimeOffset ToDateTimeOffset(string s, string format) => throw null;
            public static System.DateTimeOffset ToDateTimeOffset(string s) => throw null;
            public static System.Decimal ToDecimal(string s) => throw null;
            public static double ToDouble(string s) => throw null;
            public static System.Guid ToGuid(string s) => throw null;
            public static System.Int16 ToInt16(string s) => throw null;
            public static int ToInt32(string s) => throw null;
            public static System.Int64 ToInt64(string s) => throw null;
            public static System.SByte ToSByte(string s) => throw null;
            public static float ToSingle(string s) => throw null;
            public static string ToString(int value) => throw null;
            public static string ToString(float value) => throw null;
            public static string ToString(double value) => throw null;
            public static string ToString(bool value) => throw null;
            public static string ToString(System.UInt64 value) => throw null;
            public static string ToString(System.UInt32 value) => throw null;
            public static string ToString(System.UInt16 value) => throw null;
            public static string ToString(System.TimeSpan value) => throw null;
            public static string ToString(System.SByte value) => throw null;
            public static string ToString(System.Int64 value) => throw null;
            public static string ToString(System.Int16 value) => throw null;
            public static string ToString(System.Guid value) => throw null;
            public static string ToString(System.Decimal value) => throw null;
            public static string ToString(System.DateTimeOffset value, string format) => throw null;
            public static string ToString(System.DateTimeOffset value) => throw null;
            public static string ToString(System.DateTime value, string format) => throw null;
            public static string ToString(System.DateTime value, System.Xml.XmlDateTimeSerializationMode dateTimeOption) => throw null;
            public static string ToString(System.DateTime value) => throw null;
            public static string ToString(System.Char value) => throw null;
            public static string ToString(System.Byte value) => throw null;
            public static System.TimeSpan ToTimeSpan(string s) => throw null;
            public static System.UInt16 ToUInt16(string s) => throw null;
            public static System.UInt32 ToUInt32(string s) => throw null;
            public static System.UInt64 ToUInt64(string s) => throw null;
            public static string VerifyNCName(string name) => throw null;
            public static string VerifyNMTOKEN(string name) => throw null;
            public static string VerifyName(string name) => throw null;
            public static string VerifyPublicId(string publicId) => throw null;
            public static string VerifyTOKEN(string token) => throw null;
            public static string VerifyWhitespace(string content) => throw null;
            public static string VerifyXmlChars(string content) => throw null;
            public XmlConvert() => throw null;
        }

        // Generated from `System.Xml.XmlDateTimeSerializationMode` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum XmlDateTimeSerializationMode
        {
            Local,
            RoundtripKind,
            Unspecified,
            Utc,
        }

        // Generated from `System.Xml.XmlDeclaration` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlDeclaration : System.Xml.XmlLinkedNode
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public string Encoding { get => throw null; set => throw null; }
            public override string InnerText { get => throw null; set => throw null; }
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public string Standalone { get => throw null; set => throw null; }
            public override string Value { get => throw null; set => throw null; }
            public string Version { get => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlDeclaration(string version, string encoding, string standalone, System.Xml.XmlDocument doc) => throw null;
        }

        // Generated from `System.Xml.XmlDocument` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlDocument : System.Xml.XmlNode
        {
            public override string BaseURI { get => throw null; }
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public virtual System.Xml.XmlAttribute CreateAttribute(string prefix, string localName, string namespaceURI) => throw null;
            public System.Xml.XmlAttribute CreateAttribute(string qualifiedName, string namespaceURI) => throw null;
            public System.Xml.XmlAttribute CreateAttribute(string name) => throw null;
            public virtual System.Xml.XmlCDataSection CreateCDataSection(string data) => throw null;
            public virtual System.Xml.XmlComment CreateComment(string data) => throw null;
            protected internal virtual System.Xml.XmlAttribute CreateDefaultAttribute(string prefix, string localName, string namespaceURI) => throw null;
            public virtual System.Xml.XmlDocumentFragment CreateDocumentFragment() => throw null;
            public virtual System.Xml.XmlDocumentType CreateDocumentType(string name, string publicId, string systemId, string internalSubset) => throw null;
            public virtual System.Xml.XmlElement CreateElement(string prefix, string localName, string namespaceURI) => throw null;
            public System.Xml.XmlElement CreateElement(string qualifiedName, string namespaceURI) => throw null;
            public System.Xml.XmlElement CreateElement(string name) => throw null;
            public virtual System.Xml.XmlEntityReference CreateEntityReference(string name) => throw null;
            public override System.Xml.XPath.XPathNavigator CreateNavigator() => throw null;
            protected internal virtual System.Xml.XPath.XPathNavigator CreateNavigator(System.Xml.XmlNode node) => throw null;
            public virtual System.Xml.XmlNode CreateNode(string nodeTypeString, string name, string namespaceURI) => throw null;
            public virtual System.Xml.XmlNode CreateNode(System.Xml.XmlNodeType type, string prefix, string name, string namespaceURI) => throw null;
            public virtual System.Xml.XmlNode CreateNode(System.Xml.XmlNodeType type, string name, string namespaceURI) => throw null;
            public virtual System.Xml.XmlProcessingInstruction CreateProcessingInstruction(string target, string data) => throw null;
            public virtual System.Xml.XmlSignificantWhitespace CreateSignificantWhitespace(string text) => throw null;
            public virtual System.Xml.XmlText CreateTextNode(string text) => throw null;
            public virtual System.Xml.XmlWhitespace CreateWhitespace(string text) => throw null;
            public virtual System.Xml.XmlDeclaration CreateXmlDeclaration(string version, string encoding, string standalone) => throw null;
            public System.Xml.XmlElement DocumentElement { get => throw null; }
            public virtual System.Xml.XmlDocumentType DocumentType { get => throw null; }
            public virtual System.Xml.XmlElement GetElementById(string elementId) => throw null;
            public virtual System.Xml.XmlNodeList GetElementsByTagName(string name) => throw null;
            public virtual System.Xml.XmlNodeList GetElementsByTagName(string localName, string namespaceURI) => throw null;
            public System.Xml.XmlImplementation Implementation { get => throw null; }
            public virtual System.Xml.XmlNode ImportNode(System.Xml.XmlNode node, bool deep) => throw null;
            public override string InnerText { set => throw null; }
            public override string InnerXml { get => throw null; set => throw null; }
            public override bool IsReadOnly { get => throw null; }
            public virtual void Load(string filename) => throw null;
            public virtual void Load(System.Xml.XmlReader reader) => throw null;
            public virtual void Load(System.IO.TextReader txtReader) => throw null;
            public virtual void Load(System.IO.Stream inStream) => throw null;
            public virtual void LoadXml(string xml) => throw null;
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public System.Xml.XmlNameTable NameTable { get => throw null; }
            public event System.Xml.XmlNodeChangedEventHandler NodeChanged;
            public event System.Xml.XmlNodeChangedEventHandler NodeChanging;
            public event System.Xml.XmlNodeChangedEventHandler NodeInserted;
            public event System.Xml.XmlNodeChangedEventHandler NodeInserting;
            public event System.Xml.XmlNodeChangedEventHandler NodeRemoved;
            public event System.Xml.XmlNodeChangedEventHandler NodeRemoving;
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override System.Xml.XmlDocument OwnerDocument { get => throw null; }
            public override System.Xml.XmlNode ParentNode { get => throw null; }
            public bool PreserveWhitespace { get => throw null; set => throw null; }
            public virtual System.Xml.XmlNode ReadNode(System.Xml.XmlReader reader) => throw null;
            public virtual void Save(string filename) => throw null;
            public virtual void Save(System.Xml.XmlWriter w) => throw null;
            public virtual void Save(System.IO.TextWriter writer) => throw null;
            public virtual void Save(System.IO.Stream outStream) => throw null;
            public override System.Xml.Schema.IXmlSchemaInfo SchemaInfo { get => throw null; }
            public System.Xml.Schema.XmlSchemaSet Schemas { get => throw null; set => throw null; }
            public void Validate(System.Xml.Schema.ValidationEventHandler validationEventHandler, System.Xml.XmlNode nodeToValidate) => throw null;
            public void Validate(System.Xml.Schema.ValidationEventHandler validationEventHandler) => throw null;
            public override void WriteContentTo(System.Xml.XmlWriter xw) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            public XmlDocument(System.Xml.XmlNameTable nt) => throw null;
            public XmlDocument() => throw null;
            protected internal XmlDocument(System.Xml.XmlImplementation imp) => throw null;
            public virtual System.Xml.XmlResolver XmlResolver { set => throw null; }
        }

        // Generated from `System.Xml.XmlDocumentFragment` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlDocumentFragment : System.Xml.XmlNode
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string InnerXml { get => throw null; set => throw null; }
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override System.Xml.XmlDocument OwnerDocument { get => throw null; }
            public override System.Xml.XmlNode ParentNode { get => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlDocumentFragment(System.Xml.XmlDocument ownerDocument) => throw null;
        }

        // Generated from `System.Xml.XmlDocumentType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlDocumentType : System.Xml.XmlLinkedNode
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public System.Xml.XmlNamedNodeMap Entities { get => throw null; }
            public string InternalSubset { get => throw null; }
            public override bool IsReadOnly { get => throw null; }
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public System.Xml.XmlNamedNodeMap Notations { get => throw null; }
            public string PublicId { get => throw null; }
            public string SystemId { get => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlDocumentType(string name, string publicId, string systemId, string internalSubset, System.Xml.XmlDocument doc) => throw null;
        }

        // Generated from `System.Xml.XmlElement` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlElement : System.Xml.XmlLinkedNode
        {
            public override System.Xml.XmlAttributeCollection Attributes { get => throw null; }
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public virtual string GetAttribute(string name) => throw null;
            public virtual string GetAttribute(string localName, string namespaceURI) => throw null;
            public virtual System.Xml.XmlAttribute GetAttributeNode(string name) => throw null;
            public virtual System.Xml.XmlAttribute GetAttributeNode(string localName, string namespaceURI) => throw null;
            public virtual System.Xml.XmlNodeList GetElementsByTagName(string name) => throw null;
            public virtual System.Xml.XmlNodeList GetElementsByTagName(string localName, string namespaceURI) => throw null;
            public virtual bool HasAttribute(string name) => throw null;
            public virtual bool HasAttribute(string localName, string namespaceURI) => throw null;
            public virtual bool HasAttributes { get => throw null; }
            public override string InnerText { get => throw null; set => throw null; }
            public override string InnerXml { get => throw null; set => throw null; }
            public bool IsEmpty { get => throw null; set => throw null; }
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override string NamespaceURI { get => throw null; }
            public override System.Xml.XmlNode NextSibling { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override System.Xml.XmlDocument OwnerDocument { get => throw null; }
            public override System.Xml.XmlNode ParentNode { get => throw null; }
            public override string Prefix { get => throw null; set => throw null; }
            public override void RemoveAll() => throw null;
            public virtual void RemoveAllAttributes() => throw null;
            public virtual void RemoveAttribute(string name) => throw null;
            public virtual void RemoveAttribute(string localName, string namespaceURI) => throw null;
            public virtual System.Xml.XmlNode RemoveAttributeAt(int i) => throw null;
            public virtual System.Xml.XmlAttribute RemoveAttributeNode(string localName, string namespaceURI) => throw null;
            public virtual System.Xml.XmlAttribute RemoveAttributeNode(System.Xml.XmlAttribute oldAttr) => throw null;
            public override System.Xml.Schema.IXmlSchemaInfo SchemaInfo { get => throw null; }
            public virtual void SetAttribute(string name, string value) => throw null;
            public virtual string SetAttribute(string localName, string namespaceURI, string value) => throw null;
            public virtual System.Xml.XmlAttribute SetAttributeNode(string localName, string namespaceURI) => throw null;
            public virtual System.Xml.XmlAttribute SetAttributeNode(System.Xml.XmlAttribute newAttr) => throw null;
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlElement(string prefix, string localName, string namespaceURI, System.Xml.XmlDocument doc) => throw null;
        }

        // Generated from `System.Xml.XmlEntity` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlEntity : System.Xml.XmlNode
        {
            public override string BaseURI { get => throw null; }
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string InnerText { get => throw null; set => throw null; }
            public override string InnerXml { get => throw null; set => throw null; }
            public override bool IsReadOnly { get => throw null; }
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public string NotationName { get => throw null; }
            public override string OuterXml { get => throw null; }
            public string PublicId { get => throw null; }
            public string SystemId { get => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
        }

        // Generated from `System.Xml.XmlEntityReference` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlEntityReference : System.Xml.XmlLinkedNode
        {
            public override string BaseURI { get => throw null; }
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override bool IsReadOnly { get => throw null; }
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override string Value { get => throw null; set => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlEntityReference(string name, System.Xml.XmlDocument doc) => throw null;
        }

        // Generated from `System.Xml.XmlException` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlException : System.SystemException
        {
            public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
            public int LineNumber { get => throw null; }
            public int LinePosition { get => throw null; }
            public override string Message { get => throw null; }
            public string SourceUri { get => throw null; }
            public XmlException(string message, System.Exception innerException, int lineNumber, int linePosition) => throw null;
            public XmlException(string message, System.Exception innerException) => throw null;
            public XmlException(string message) => throw null;
            public XmlException() => throw null;
            protected XmlException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
        }

        // Generated from `System.Xml.XmlImplementation` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlImplementation
        {
            public virtual System.Xml.XmlDocument CreateDocument() => throw null;
            public bool HasFeature(string strFeature, string strVersion) => throw null;
            public XmlImplementation(System.Xml.XmlNameTable nt) => throw null;
            public XmlImplementation() => throw null;
        }

        // Generated from `System.Xml.XmlLinkedNode` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public abstract class XmlLinkedNode : System.Xml.XmlNode
        {
            public override System.Xml.XmlNode NextSibling { get => throw null; }
            public override System.Xml.XmlNode PreviousSibling { get => throw null; }
            internal XmlLinkedNode() => throw null;
        }

        // Generated from `System.Xml.XmlNameTable` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public abstract class XmlNameTable
        {
            public abstract string Add(string array);
            public abstract string Add(System.Char[] array, int offset, int length);
            public abstract string Get(string array);
            public abstract string Get(System.Char[] array, int offset, int length);
            protected XmlNameTable() => throw null;
        }

        // Generated from `System.Xml.XmlNamedNodeMap` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlNamedNodeMap : System.Collections.IEnumerable
        {
            public virtual int Count { get => throw null; }
            public virtual System.Collections.IEnumerator GetEnumerator() => throw null;
            public virtual System.Xml.XmlNode GetNamedItem(string name) => throw null;
            public virtual System.Xml.XmlNode GetNamedItem(string localName, string namespaceURI) => throw null;
            public virtual System.Xml.XmlNode Item(int index) => throw null;
            public virtual System.Xml.XmlNode RemoveNamedItem(string name) => throw null;
            public virtual System.Xml.XmlNode RemoveNamedItem(string localName, string namespaceURI) => throw null;
            public virtual System.Xml.XmlNode SetNamedItem(System.Xml.XmlNode node) => throw null;
            internal XmlNamedNodeMap() => throw null;
        }

        // Generated from `System.Xml.XmlNamespaceManager` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlNamespaceManager : System.Xml.IXmlNamespaceResolver, System.Collections.IEnumerable
        {
            public virtual void AddNamespace(string prefix, string uri) => throw null;
            public virtual string DefaultNamespace { get => throw null; }
            public virtual System.Collections.IEnumerator GetEnumerator() => throw null;
            public virtual System.Collections.Generic.IDictionary<string, string> GetNamespacesInScope(System.Xml.XmlNamespaceScope scope) => throw null;
            public virtual bool HasNamespace(string prefix) => throw null;
            public virtual string LookupNamespace(string prefix) => throw null;
            public virtual string LookupPrefix(string uri) => throw null;
            public virtual System.Xml.XmlNameTable NameTable { get => throw null; }
            public virtual bool PopScope() => throw null;
            public virtual void PushScope() => throw null;
            public virtual void RemoveNamespace(string prefix, string uri) => throw null;
            public XmlNamespaceManager(System.Xml.XmlNameTable nameTable) => throw null;
        }

        // Generated from `System.Xml.XmlNamespaceScope` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum XmlNamespaceScope
        {
            All,
            ExcludeXml,
            Local,
        }

        // Generated from `System.Xml.XmlNode` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public abstract class XmlNode : System.Xml.XPath.IXPathNavigable, System.ICloneable, System.Collections.IEnumerable
        {
            public virtual System.Xml.XmlNode AppendChild(System.Xml.XmlNode newChild) => throw null;
            public virtual System.Xml.XmlAttributeCollection Attributes { get => throw null; }
            public virtual string BaseURI { get => throw null; }
            public virtual System.Xml.XmlNodeList ChildNodes { get => throw null; }
            public virtual System.Xml.XmlNode Clone() => throw null;
            object System.ICloneable.Clone() => throw null;
            public abstract System.Xml.XmlNode CloneNode(bool deep);
            public virtual System.Xml.XPath.XPathNavigator CreateNavigator() => throw null;
            public virtual System.Xml.XmlNode FirstChild { get => throw null; }
            public System.Collections.IEnumerator GetEnumerator() => throw null;
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => throw null;
            public virtual string GetNamespaceOfPrefix(string prefix) => throw null;
            public virtual string GetPrefixOfNamespace(string namespaceURI) => throw null;
            public virtual bool HasChildNodes { get => throw null; }
            public virtual string InnerText { get => throw null; set => throw null; }
            public virtual string InnerXml { get => throw null; set => throw null; }
            public virtual System.Xml.XmlNode InsertAfter(System.Xml.XmlNode newChild, System.Xml.XmlNode refChild) => throw null;
            public virtual System.Xml.XmlNode InsertBefore(System.Xml.XmlNode newChild, System.Xml.XmlNode refChild) => throw null;
            public virtual bool IsReadOnly { get => throw null; }
            public virtual System.Xml.XmlElement this[string name] { get => throw null; }
            public virtual System.Xml.XmlElement this[string localname, string ns] { get => throw null; }
            public virtual System.Xml.XmlNode LastChild { get => throw null; }
            public abstract string LocalName { get; }
            public abstract string Name { get; }
            public virtual string NamespaceURI { get => throw null; }
            public virtual System.Xml.XmlNode NextSibling { get => throw null; }
            public abstract System.Xml.XmlNodeType NodeType { get; }
            public virtual void Normalize() => throw null;
            public virtual string OuterXml { get => throw null; }
            public virtual System.Xml.XmlDocument OwnerDocument { get => throw null; }
            public virtual System.Xml.XmlNode ParentNode { get => throw null; }
            public virtual string Prefix { get => throw null; set => throw null; }
            public virtual System.Xml.XmlNode PrependChild(System.Xml.XmlNode newChild) => throw null;
            public virtual System.Xml.XmlNode PreviousSibling { get => throw null; }
            public virtual System.Xml.XmlNode PreviousText { get => throw null; }
            public virtual void RemoveAll() => throw null;
            public virtual System.Xml.XmlNode RemoveChild(System.Xml.XmlNode oldChild) => throw null;
            public virtual System.Xml.XmlNode ReplaceChild(System.Xml.XmlNode newChild, System.Xml.XmlNode oldChild) => throw null;
            public virtual System.Xml.Schema.IXmlSchemaInfo SchemaInfo { get => throw null; }
            public System.Xml.XmlNodeList SelectNodes(string xpath, System.Xml.XmlNamespaceManager nsmgr) => throw null;
            public System.Xml.XmlNodeList SelectNodes(string xpath) => throw null;
            public System.Xml.XmlNode SelectSingleNode(string xpath, System.Xml.XmlNamespaceManager nsmgr) => throw null;
            public System.Xml.XmlNode SelectSingleNode(string xpath) => throw null;
            public virtual bool Supports(string feature, string version) => throw null;
            public virtual string Value { get => throw null; set => throw null; }
            public abstract void WriteContentTo(System.Xml.XmlWriter w);
            public abstract void WriteTo(System.Xml.XmlWriter w);
            internal XmlNode() => throw null;
        }

        // Generated from `System.Xml.XmlNodeChangedAction` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum XmlNodeChangedAction
        {
            Change,
            Insert,
            Remove,
        }

        // Generated from `System.Xml.XmlNodeChangedEventArgs` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlNodeChangedEventArgs : System.EventArgs
        {
            public System.Xml.XmlNodeChangedAction Action { get => throw null; }
            public System.Xml.XmlNode NewParent { get => throw null; }
            public string NewValue { get => throw null; }
            public System.Xml.XmlNode Node { get => throw null; }
            public System.Xml.XmlNode OldParent { get => throw null; }
            public string OldValue { get => throw null; }
            public XmlNodeChangedEventArgs(System.Xml.XmlNode node, System.Xml.XmlNode oldParent, System.Xml.XmlNode newParent, string oldValue, string newValue, System.Xml.XmlNodeChangedAction action) => throw null;
        }

        // Generated from `System.Xml.XmlNodeChangedEventHandler` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public delegate void XmlNodeChangedEventHandler(object sender, System.Xml.XmlNodeChangedEventArgs e);

        // Generated from `System.Xml.XmlNodeList` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public abstract class XmlNodeList : System.IDisposable, System.Collections.IEnumerable
        {
            public abstract int Count { get; }
            void System.IDisposable.Dispose() => throw null;
            public abstract System.Collections.IEnumerator GetEnumerator();
            public abstract System.Xml.XmlNode Item(int index);
            [System.Runtime.CompilerServices.IndexerName("ItemOf")]
            public virtual System.Xml.XmlNode this[int i] { get => throw null; }
            protected virtual void PrivateDisposeNodeList() => throw null;
            protected XmlNodeList() => throw null;
        }

        // Generated from `System.Xml.XmlNodeOrder` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum XmlNodeOrder
        {
            After,
            Before,
            Same,
            Unknown,
        }

        // Generated from `System.Xml.XmlNodeReader` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlNodeReader : System.Xml.XmlReader, System.Xml.IXmlNamespaceResolver
        {
            public override int AttributeCount { get => throw null; }
            public override string BaseURI { get => throw null; }
            public override bool CanReadBinaryContent { get => throw null; }
            public override bool CanResolveEntity { get => throw null; }
            public override void Close() => throw null;
            public override int Depth { get => throw null; }
            public override bool EOF { get => throw null; }
            public override string GetAttribute(string name, string namespaceURI) => throw null;
            public override string GetAttribute(string name) => throw null;
            public override string GetAttribute(int attributeIndex) => throw null;
            System.Collections.Generic.IDictionary<string, string> System.Xml.IXmlNamespaceResolver.GetNamespacesInScope(System.Xml.XmlNamespaceScope scope) => throw null;
            public override bool HasAttributes { get => throw null; }
            public override bool HasValue { get => throw null; }
            public override bool IsDefault { get => throw null; }
            public override bool IsEmptyElement { get => throw null; }
            public override string LocalName { get => throw null; }
            string System.Xml.IXmlNamespaceResolver.LookupNamespace(string prefix) => throw null;
            public override string LookupNamespace(string prefix) => throw null;
            string System.Xml.IXmlNamespaceResolver.LookupPrefix(string namespaceName) => throw null;
            public override void MoveToAttribute(int attributeIndex) => throw null;
            public override bool MoveToAttribute(string name, string namespaceURI) => throw null;
            public override bool MoveToAttribute(string name) => throw null;
            public override bool MoveToElement() => throw null;
            public override bool MoveToFirstAttribute() => throw null;
            public override bool MoveToNextAttribute() => throw null;
            public override string Name { get => throw null; }
            public override System.Xml.XmlNameTable NameTable { get => throw null; }
            public override string NamespaceURI { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override string Prefix { get => throw null; }
            public override bool Read() => throw null;
            public override bool ReadAttributeValue() => throw null;
            public override int ReadContentAsBase64(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadContentAsBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadElementContentAsBase64(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadElementContentAsBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public override System.Xml.ReadState ReadState { get => throw null; }
            public override string ReadString() => throw null;
            public override void ResolveEntity() => throw null;
            public override System.Xml.Schema.IXmlSchemaInfo SchemaInfo { get => throw null; }
            public override void Skip() => throw null;
            public override string Value { get => throw null; }
            public override string XmlLang { get => throw null; }
            public XmlNodeReader(System.Xml.XmlNode node) => throw null;
            public override System.Xml.XmlSpace XmlSpace { get => throw null; }
        }

        // Generated from `System.Xml.XmlNodeType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum XmlNodeType
        {
            Attribute,
            CDATA,
            Comment,
            Document,
            DocumentFragment,
            DocumentType,
            Element,
            EndElement,
            EndEntity,
            Entity,
            EntityReference,
            None,
            Notation,
            ProcessingInstruction,
            SignificantWhitespace,
            Text,
            Whitespace,
            XmlDeclaration,
        }

        // Generated from `System.Xml.XmlNotation` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlNotation : System.Xml.XmlNode
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string InnerXml { get => throw null; set => throw null; }
            public override bool IsReadOnly { get => throw null; }
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override string OuterXml { get => throw null; }
            public string PublicId { get => throw null; }
            public string SystemId { get => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
        }

        // Generated from `System.Xml.XmlOutputMethod` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum XmlOutputMethod
        {
            AutoDetect,
            Html,
            Text,
            Xml,
        }

        // Generated from `System.Xml.XmlParserContext` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlParserContext
        {
            public string BaseURI { get => throw null; set => throw null; }
            public string DocTypeName { get => throw null; set => throw null; }
            public System.Text.Encoding Encoding { get => throw null; set => throw null; }
            public string InternalSubset { get => throw null; set => throw null; }
            public System.Xml.XmlNameTable NameTable { get => throw null; set => throw null; }
            public System.Xml.XmlNamespaceManager NamespaceManager { get => throw null; set => throw null; }
            public string PublicId { get => throw null; set => throw null; }
            public string SystemId { get => throw null; set => throw null; }
            public string XmlLang { get => throw null; set => throw null; }
            public XmlParserContext(System.Xml.XmlNameTable nt, System.Xml.XmlNamespaceManager nsMgr, string xmlLang, System.Xml.XmlSpace xmlSpace, System.Text.Encoding enc) => throw null;
            public XmlParserContext(System.Xml.XmlNameTable nt, System.Xml.XmlNamespaceManager nsMgr, string xmlLang, System.Xml.XmlSpace xmlSpace) => throw null;
            public XmlParserContext(System.Xml.XmlNameTable nt, System.Xml.XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, System.Xml.XmlSpace xmlSpace, System.Text.Encoding enc) => throw null;
            public XmlParserContext(System.Xml.XmlNameTable nt, System.Xml.XmlNamespaceManager nsMgr, string docTypeName, string pubId, string sysId, string internalSubset, string baseURI, string xmlLang, System.Xml.XmlSpace xmlSpace) => throw null;
            public System.Xml.XmlSpace XmlSpace { get => throw null; set => throw null; }
        }

        // Generated from `System.Xml.XmlProcessingInstruction` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlProcessingInstruction : System.Xml.XmlLinkedNode
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public string Data { get => throw null; set => throw null; }
            public override string InnerText { get => throw null; set => throw null; }
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public string Target { get => throw null; }
            public override string Value { get => throw null; set => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlProcessingInstruction(string target, string data, System.Xml.XmlDocument doc) => throw null;
        }

        // Generated from `System.Xml.XmlQualifiedName` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlQualifiedName
        {
            public static bool operator !=(System.Xml.XmlQualifiedName a, System.Xml.XmlQualifiedName b) => throw null;
            public static bool operator ==(System.Xml.XmlQualifiedName a, System.Xml.XmlQualifiedName b) => throw null;
            public static System.Xml.XmlQualifiedName Empty;
            public override bool Equals(object other) => throw null;
            public override int GetHashCode() => throw null;
            public bool IsEmpty { get => throw null; }
            public string Name { get => throw null; }
            public string Namespace { get => throw null; }
            public static string ToString(string name, string ns) => throw null;
            public override string ToString() => throw null;
            public XmlQualifiedName(string name, string ns) => throw null;
            public XmlQualifiedName(string name) => throw null;
            public XmlQualifiedName() => throw null;
        }

        // Generated from `System.Xml.XmlReader` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public abstract class XmlReader : System.IDisposable
        {
            public abstract int AttributeCount { get; }
            public abstract string BaseURI { get; }
            public virtual bool CanReadBinaryContent { get => throw null; }
            public virtual bool CanReadValueChunk { get => throw null; }
            public virtual bool CanResolveEntity { get => throw null; }
            public virtual void Close() => throw null;
            public static System.Xml.XmlReader Create(string inputUri, System.Xml.XmlReaderSettings settings, System.Xml.XmlParserContext inputContext) => throw null;
            public static System.Xml.XmlReader Create(string inputUri, System.Xml.XmlReaderSettings settings) => throw null;
            public static System.Xml.XmlReader Create(string inputUri) => throw null;
            public static System.Xml.XmlReader Create(System.Xml.XmlReader reader, System.Xml.XmlReaderSettings settings) => throw null;
            public static System.Xml.XmlReader Create(System.IO.TextReader input, System.Xml.XmlReaderSettings settings, string baseUri) => throw null;
            public static System.Xml.XmlReader Create(System.IO.TextReader input, System.Xml.XmlReaderSettings settings, System.Xml.XmlParserContext inputContext) => throw null;
            public static System.Xml.XmlReader Create(System.IO.TextReader input, System.Xml.XmlReaderSettings settings) => throw null;
            public static System.Xml.XmlReader Create(System.IO.TextReader input) => throw null;
            public static System.Xml.XmlReader Create(System.IO.Stream input, System.Xml.XmlReaderSettings settings, string baseUri) => throw null;
            public static System.Xml.XmlReader Create(System.IO.Stream input, System.Xml.XmlReaderSettings settings, System.Xml.XmlParserContext inputContext) => throw null;
            public static System.Xml.XmlReader Create(System.IO.Stream input, System.Xml.XmlReaderSettings settings) => throw null;
            public static System.Xml.XmlReader Create(System.IO.Stream input) => throw null;
            public abstract int Depth { get; }
            public void Dispose() => throw null;
            protected virtual void Dispose(bool disposing) => throw null;
            public abstract bool EOF { get; }
            public abstract string GetAttribute(string name, string namespaceURI);
            public abstract string GetAttribute(string name);
            public abstract string GetAttribute(int i);
            public virtual System.Threading.Tasks.Task<string> GetValueAsync() => throw null;
            public virtual bool HasAttributes { get => throw null; }
            public virtual bool HasValue { get => throw null; }
            public virtual bool IsDefault { get => throw null; }
            public abstract bool IsEmptyElement { get; }
            public static bool IsName(string str) => throw null;
            public static bool IsNameToken(string str) => throw null;
            public virtual bool IsStartElement(string name) => throw null;
            public virtual bool IsStartElement(string localname, string ns) => throw null;
            public virtual bool IsStartElement() => throw null;
            public virtual string this[string name] { get => throw null; }
            public virtual string this[string name, string namespaceURI] { get => throw null; }
            public virtual string this[int i] { get => throw null; }
            public abstract string LocalName { get; }
            public abstract string LookupNamespace(string prefix);
            public virtual void MoveToAttribute(int i) => throw null;
            public abstract bool MoveToAttribute(string name, string ns);
            public abstract bool MoveToAttribute(string name);
            public virtual System.Xml.XmlNodeType MoveToContent() => throw null;
            public virtual System.Threading.Tasks.Task<System.Xml.XmlNodeType> MoveToContentAsync() => throw null;
            public abstract bool MoveToElement();
            public abstract bool MoveToFirstAttribute();
            public abstract bool MoveToNextAttribute();
            public virtual string Name { get => throw null; }
            public abstract System.Xml.XmlNameTable NameTable { get; }
            public abstract string NamespaceURI { get; }
            public abstract System.Xml.XmlNodeType NodeType { get; }
            public abstract string Prefix { get; }
            public virtual System.Char QuoteChar { get => throw null; }
            public abstract bool Read();
            public virtual System.Threading.Tasks.Task<bool> ReadAsync() => throw null;
            public abstract bool ReadAttributeValue();
            public virtual object ReadContentAs(System.Type returnType, System.Xml.IXmlNamespaceResolver namespaceResolver) => throw null;
            public virtual System.Threading.Tasks.Task<object> ReadContentAsAsync(System.Type returnType, System.Xml.IXmlNamespaceResolver namespaceResolver) => throw null;
            public virtual int ReadContentAsBase64(System.Byte[] buffer, int index, int count) => throw null;
            public virtual System.Threading.Tasks.Task<int> ReadContentAsBase64Async(System.Byte[] buffer, int index, int count) => throw null;
            public virtual int ReadContentAsBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public virtual System.Threading.Tasks.Task<int> ReadContentAsBinHexAsync(System.Byte[] buffer, int index, int count) => throw null;
            public virtual bool ReadContentAsBoolean() => throw null;
            public virtual System.DateTime ReadContentAsDateTime() => throw null;
            public virtual System.DateTimeOffset ReadContentAsDateTimeOffset() => throw null;
            public virtual System.Decimal ReadContentAsDecimal() => throw null;
            public virtual double ReadContentAsDouble() => throw null;
            public virtual float ReadContentAsFloat() => throw null;
            public virtual int ReadContentAsInt() => throw null;
            public virtual System.Int64 ReadContentAsLong() => throw null;
            public virtual object ReadContentAsObject() => throw null;
            public virtual System.Threading.Tasks.Task<object> ReadContentAsObjectAsync() => throw null;
            public virtual string ReadContentAsString() => throw null;
            public virtual System.Threading.Tasks.Task<string> ReadContentAsStringAsync() => throw null;
            public virtual object ReadElementContentAs(System.Type returnType, System.Xml.IXmlNamespaceResolver namespaceResolver, string localName, string namespaceURI) => throw null;
            public virtual object ReadElementContentAs(System.Type returnType, System.Xml.IXmlNamespaceResolver namespaceResolver) => throw null;
            public virtual System.Threading.Tasks.Task<object> ReadElementContentAsAsync(System.Type returnType, System.Xml.IXmlNamespaceResolver namespaceResolver) => throw null;
            public virtual int ReadElementContentAsBase64(System.Byte[] buffer, int index, int count) => throw null;
            public virtual System.Threading.Tasks.Task<int> ReadElementContentAsBase64Async(System.Byte[] buffer, int index, int count) => throw null;
            public virtual int ReadElementContentAsBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public virtual System.Threading.Tasks.Task<int> ReadElementContentAsBinHexAsync(System.Byte[] buffer, int index, int count) => throw null;
            public virtual bool ReadElementContentAsBoolean(string localName, string namespaceURI) => throw null;
            public virtual bool ReadElementContentAsBoolean() => throw null;
            public virtual System.DateTime ReadElementContentAsDateTime(string localName, string namespaceURI) => throw null;
            public virtual System.DateTime ReadElementContentAsDateTime() => throw null;
            public virtual System.Decimal ReadElementContentAsDecimal(string localName, string namespaceURI) => throw null;
            public virtual System.Decimal ReadElementContentAsDecimal() => throw null;
            public virtual double ReadElementContentAsDouble(string localName, string namespaceURI) => throw null;
            public virtual double ReadElementContentAsDouble() => throw null;
            public virtual float ReadElementContentAsFloat(string localName, string namespaceURI) => throw null;
            public virtual float ReadElementContentAsFloat() => throw null;
            public virtual int ReadElementContentAsInt(string localName, string namespaceURI) => throw null;
            public virtual int ReadElementContentAsInt() => throw null;
            public virtual System.Int64 ReadElementContentAsLong(string localName, string namespaceURI) => throw null;
            public virtual System.Int64 ReadElementContentAsLong() => throw null;
            public virtual object ReadElementContentAsObject(string localName, string namespaceURI) => throw null;
            public virtual object ReadElementContentAsObject() => throw null;
            public virtual System.Threading.Tasks.Task<object> ReadElementContentAsObjectAsync() => throw null;
            public virtual string ReadElementContentAsString(string localName, string namespaceURI) => throw null;
            public virtual string ReadElementContentAsString() => throw null;
            public virtual System.Threading.Tasks.Task<string> ReadElementContentAsStringAsync() => throw null;
            public virtual string ReadElementString(string name) => throw null;
            public virtual string ReadElementString(string localname, string ns) => throw null;
            public virtual string ReadElementString() => throw null;
            public virtual void ReadEndElement() => throw null;
            public virtual string ReadInnerXml() => throw null;
            public virtual System.Threading.Tasks.Task<string> ReadInnerXmlAsync() => throw null;
            public virtual string ReadOuterXml() => throw null;
            public virtual System.Threading.Tasks.Task<string> ReadOuterXmlAsync() => throw null;
            public virtual void ReadStartElement(string name) => throw null;
            public virtual void ReadStartElement(string localname, string ns) => throw null;
            public virtual void ReadStartElement() => throw null;
            public abstract System.Xml.ReadState ReadState { get; }
            public virtual string ReadString() => throw null;
            public virtual System.Xml.XmlReader ReadSubtree() => throw null;
            public virtual bool ReadToDescendant(string name) => throw null;
            public virtual bool ReadToDescendant(string localName, string namespaceURI) => throw null;
            public virtual bool ReadToFollowing(string name) => throw null;
            public virtual bool ReadToFollowing(string localName, string namespaceURI) => throw null;
            public virtual bool ReadToNextSibling(string name) => throw null;
            public virtual bool ReadToNextSibling(string localName, string namespaceURI) => throw null;
            public virtual int ReadValueChunk(System.Char[] buffer, int index, int count) => throw null;
            public virtual System.Threading.Tasks.Task<int> ReadValueChunkAsync(System.Char[] buffer, int index, int count) => throw null;
            public abstract void ResolveEntity();
            public virtual System.Xml.Schema.IXmlSchemaInfo SchemaInfo { get => throw null; }
            public virtual System.Xml.XmlReaderSettings Settings { get => throw null; }
            public virtual void Skip() => throw null;
            public virtual System.Threading.Tasks.Task SkipAsync() => throw null;
            public abstract string Value { get; }
            public virtual System.Type ValueType { get => throw null; }
            public virtual string XmlLang { get => throw null; }
            protected XmlReader() => throw null;
            public virtual System.Xml.XmlSpace XmlSpace { get => throw null; }
        }

        // Generated from `System.Xml.XmlReaderSettings` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlReaderSettings
        {
            public bool Async { get => throw null; set => throw null; }
            public bool CheckCharacters { get => throw null; set => throw null; }
            public System.Xml.XmlReaderSettings Clone() => throw null;
            public bool CloseInput { get => throw null; set => throw null; }
            public System.Xml.ConformanceLevel ConformanceLevel { get => throw null; set => throw null; }
            public System.Xml.DtdProcessing DtdProcessing { get => throw null; set => throw null; }
            public bool IgnoreComments { get => throw null; set => throw null; }
            public bool IgnoreProcessingInstructions { get => throw null; set => throw null; }
            public bool IgnoreWhitespace { get => throw null; set => throw null; }
            public int LineNumberOffset { get => throw null; set => throw null; }
            public int LinePositionOffset { get => throw null; set => throw null; }
            public System.Int64 MaxCharactersFromEntities { get => throw null; set => throw null; }
            public System.Int64 MaxCharactersInDocument { get => throw null; set => throw null; }
            public System.Xml.XmlNameTable NameTable { get => throw null; set => throw null; }
            public bool ProhibitDtd { get => throw null; set => throw null; }
            public void Reset() => throw null;
            public System.Xml.Schema.XmlSchemaSet Schemas { get => throw null; set => throw null; }
            public event System.Xml.Schema.ValidationEventHandler ValidationEventHandler;
            public System.Xml.Schema.XmlSchemaValidationFlags ValidationFlags { get => throw null; set => throw null; }
            public System.Xml.ValidationType ValidationType { get => throw null; set => throw null; }
            public XmlReaderSettings() => throw null;
            public System.Xml.XmlResolver XmlResolver { set => throw null; }
        }

        // Generated from `System.Xml.XmlResolver` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public abstract class XmlResolver
        {
            public virtual System.Net.ICredentials Credentials { set => throw null; }
            public abstract object GetEntity(System.Uri absoluteUri, string role, System.Type ofObjectToReturn);
            public virtual System.Threading.Tasks.Task<object> GetEntityAsync(System.Uri absoluteUri, string role, System.Type ofObjectToReturn) => throw null;
            public virtual System.Uri ResolveUri(System.Uri baseUri, string relativeUri) => throw null;
            public virtual bool SupportsType(System.Uri absoluteUri, System.Type type) => throw null;
            protected XmlResolver() => throw null;
        }

        // Generated from `System.Xml.XmlSecureResolver` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlSecureResolver : System.Xml.XmlResolver
        {
            public override System.Net.ICredentials Credentials { set => throw null; }
            public override object GetEntity(System.Uri absoluteUri, string role, System.Type ofObjectToReturn) => throw null;
            public override System.Threading.Tasks.Task<object> GetEntityAsync(System.Uri absoluteUri, string role, System.Type ofObjectToReturn) => throw null;
            public override System.Uri ResolveUri(System.Uri baseUri, string relativeUri) => throw null;
            public XmlSecureResolver(System.Xml.XmlResolver resolver, string securityUrl) => throw null;
        }

        // Generated from `System.Xml.XmlSignificantWhitespace` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlSignificantWhitespace : System.Xml.XmlCharacterData
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override System.Xml.XmlNode ParentNode { get => throw null; }
            public override System.Xml.XmlNode PreviousText { get => throw null; }
            public override string Value { get => throw null; set => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlSignificantWhitespace(string strData, System.Xml.XmlDocument doc) : base(default(string), default(System.Xml.XmlDocument)) => throw null;
        }

        // Generated from `System.Xml.XmlSpace` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum XmlSpace
        {
            Default,
            None,
            Preserve,
        }

        // Generated from `System.Xml.XmlText` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlText : System.Xml.XmlCharacterData
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override System.Xml.XmlNode ParentNode { get => throw null; }
            public override System.Xml.XmlNode PreviousText { get => throw null; }
            public virtual System.Xml.XmlText SplitText(int offset) => throw null;
            public override string Value { get => throw null; set => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlText(string strData, System.Xml.XmlDocument doc) : base(default(string), default(System.Xml.XmlDocument)) => throw null;
        }

        // Generated from `System.Xml.XmlTextReader` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlTextReader : System.Xml.XmlReader, System.Xml.IXmlNamespaceResolver, System.Xml.IXmlLineInfo
        {
            public override int AttributeCount { get => throw null; }
            public override string BaseURI { get => throw null; }
            public override bool CanReadBinaryContent { get => throw null; }
            public override bool CanReadValueChunk { get => throw null; }
            public override bool CanResolveEntity { get => throw null; }
            public override void Close() => throw null;
            public override int Depth { get => throw null; }
            public System.Xml.DtdProcessing DtdProcessing { get => throw null; set => throw null; }
            public override bool EOF { get => throw null; }
            public System.Text.Encoding Encoding { get => throw null; }
            public System.Xml.EntityHandling EntityHandling { get => throw null; set => throw null; }
            public override string GetAttribute(string name) => throw null;
            public override string GetAttribute(string localName, string namespaceURI) => throw null;
            public override string GetAttribute(int i) => throw null;
            public System.Collections.Generic.IDictionary<string, string> GetNamespacesInScope(System.Xml.XmlNamespaceScope scope) => throw null;
            System.Collections.Generic.IDictionary<string, string> System.Xml.IXmlNamespaceResolver.GetNamespacesInScope(System.Xml.XmlNamespaceScope scope) => throw null;
            public System.IO.TextReader GetRemainder() => throw null;
            public bool HasLineInfo() => throw null;
            public override bool HasValue { get => throw null; }
            public override bool IsDefault { get => throw null; }
            public override bool IsEmptyElement { get => throw null; }
            public int LineNumber { get => throw null; }
            public int LinePosition { get => throw null; }
            public override string LocalName { get => throw null; }
            string System.Xml.IXmlNamespaceResolver.LookupNamespace(string prefix) => throw null;
            public override string LookupNamespace(string prefix) => throw null;
            string System.Xml.IXmlNamespaceResolver.LookupPrefix(string namespaceName) => throw null;
            public override void MoveToAttribute(int i) => throw null;
            public override bool MoveToAttribute(string name) => throw null;
            public override bool MoveToAttribute(string localName, string namespaceURI) => throw null;
            public override bool MoveToElement() => throw null;
            public override bool MoveToFirstAttribute() => throw null;
            public override bool MoveToNextAttribute() => throw null;
            public override string Name { get => throw null; }
            public override System.Xml.XmlNameTable NameTable { get => throw null; }
            public override string NamespaceURI { get => throw null; }
            public bool Namespaces { get => throw null; set => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public bool Normalization { get => throw null; set => throw null; }
            public override string Prefix { get => throw null; }
            public bool ProhibitDtd { get => throw null; set => throw null; }
            public override System.Char QuoteChar { get => throw null; }
            public override bool Read() => throw null;
            public override bool ReadAttributeValue() => throw null;
            public int ReadBase64(System.Byte[] array, int offset, int len) => throw null;
            public int ReadBinHex(System.Byte[] array, int offset, int len) => throw null;
            public int ReadChars(System.Char[] buffer, int index, int count) => throw null;
            public override int ReadContentAsBase64(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadContentAsBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadElementContentAsBase64(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadElementContentAsBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public override System.Xml.ReadState ReadState { get => throw null; }
            public override string ReadString() => throw null;
            public void ResetState() => throw null;
            public override void ResolveEntity() => throw null;
            public override void Skip() => throw null;
            public override string Value { get => throw null; }
            public System.Xml.WhitespaceHandling WhitespaceHandling { get => throw null; set => throw null; }
            public override string XmlLang { get => throw null; }
            public System.Xml.XmlResolver XmlResolver { set => throw null; }
            public override System.Xml.XmlSpace XmlSpace { get => throw null; }
            public XmlTextReader(string xmlFragment, System.Xml.XmlNodeType fragType, System.Xml.XmlParserContext context) => throw null;
            public XmlTextReader(string url, System.Xml.XmlNameTable nt) => throw null;
            public XmlTextReader(string url, System.IO.TextReader input, System.Xml.XmlNameTable nt) => throw null;
            public XmlTextReader(string url, System.IO.TextReader input) => throw null;
            public XmlTextReader(string url, System.IO.Stream input, System.Xml.XmlNameTable nt) => throw null;
            public XmlTextReader(string url, System.IO.Stream input) => throw null;
            public XmlTextReader(string url) => throw null;
            public XmlTextReader(System.IO.TextReader input, System.Xml.XmlNameTable nt) => throw null;
            public XmlTextReader(System.IO.TextReader input) => throw null;
            public XmlTextReader(System.IO.Stream xmlFragment, System.Xml.XmlNodeType fragType, System.Xml.XmlParserContext context) => throw null;
            public XmlTextReader(System.IO.Stream input, System.Xml.XmlNameTable nt) => throw null;
            public XmlTextReader(System.IO.Stream input) => throw null;
            protected XmlTextReader(System.Xml.XmlNameTable nt) => throw null;
            protected XmlTextReader() => throw null;
        }

        // Generated from `System.Xml.XmlTextWriter` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlTextWriter : System.Xml.XmlWriter
        {
            public System.IO.Stream BaseStream { get => throw null; }
            public override void Close() => throw null;
            public override void Flush() => throw null;
            public System.Xml.Formatting Formatting { get => throw null; set => throw null; }
            public System.Char IndentChar { get => throw null; set => throw null; }
            public int Indentation { get => throw null; set => throw null; }
            public override string LookupPrefix(string ns) => throw null;
            public bool Namespaces { get => throw null; set => throw null; }
            public System.Char QuoteChar { get => throw null; set => throw null; }
            public override void WriteBase64(System.Byte[] buffer, int index, int count) => throw null;
            public override void WriteBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public override void WriteCData(string text) => throw null;
            public override void WriteCharEntity(System.Char ch) => throw null;
            public override void WriteChars(System.Char[] buffer, int index, int count) => throw null;
            public override void WriteComment(string text) => throw null;
            public override void WriteDocType(string name, string pubid, string sysid, string subset) => throw null;
            public override void WriteEndAttribute() => throw null;
            public override void WriteEndDocument() => throw null;
            public override void WriteEndElement() => throw null;
            public override void WriteEntityRef(string name) => throw null;
            public override void WriteFullEndElement() => throw null;
            public override void WriteName(string name) => throw null;
            public override void WriteNmToken(string name) => throw null;
            public override void WriteProcessingInstruction(string name, string text) => throw null;
            public override void WriteQualifiedName(string localName, string ns) => throw null;
            public override void WriteRaw(string data) => throw null;
            public override void WriteRaw(System.Char[] buffer, int index, int count) => throw null;
            public override void WriteStartAttribute(string prefix, string localName, string ns) => throw null;
            public override void WriteStartDocument(bool standalone) => throw null;
            public override void WriteStartDocument() => throw null;
            public override void WriteStartElement(string prefix, string localName, string ns) => throw null;
            public override System.Xml.WriteState WriteState { get => throw null; }
            public override void WriteString(string text) => throw null;
            public override void WriteSurrogateCharEntity(System.Char lowChar, System.Char highChar) => throw null;
            public override void WriteWhitespace(string ws) => throw null;
            public override string XmlLang { get => throw null; }
            public override System.Xml.XmlSpace XmlSpace { get => throw null; }
            public XmlTextWriter(string filename, System.Text.Encoding encoding) => throw null;
            public XmlTextWriter(System.IO.TextWriter w) => throw null;
            public XmlTextWriter(System.IO.Stream w, System.Text.Encoding encoding) => throw null;
        }

        // Generated from `System.Xml.XmlTokenizedType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public enum XmlTokenizedType
        {
            CDATA,
            ENTITIES,
            ENTITY,
            ENUMERATION,
            ID,
            IDREF,
            IDREFS,
            NCName,
            NMTOKEN,
            NMTOKENS,
            NOTATION,
            None,
            QName,
        }

        // Generated from `System.Xml.XmlUrlResolver` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlUrlResolver : System.Xml.XmlResolver
        {
            public System.Net.Cache.RequestCachePolicy CachePolicy { set => throw null; }
            public override System.Net.ICredentials Credentials { set => throw null; }
            public override object GetEntity(System.Uri absoluteUri, string role, System.Type ofObjectToReturn) => throw null;
            public override System.Threading.Tasks.Task<object> GetEntityAsync(System.Uri absoluteUri, string role, System.Type ofObjectToReturn) => throw null;
            public System.Net.IWebProxy Proxy { set => throw null; }
            public override System.Uri ResolveUri(System.Uri baseUri, string relativeUri) => throw null;
            public XmlUrlResolver() => throw null;
        }

        // Generated from `System.Xml.XmlValidatingReader` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlValidatingReader : System.Xml.XmlReader, System.Xml.IXmlNamespaceResolver, System.Xml.IXmlLineInfo
        {
            public override int AttributeCount { get => throw null; }
            public override string BaseURI { get => throw null; }
            public override bool CanReadBinaryContent { get => throw null; }
            public override bool CanResolveEntity { get => throw null; }
            public override void Close() => throw null;
            public override int Depth { get => throw null; }
            public override bool EOF { get => throw null; }
            public System.Text.Encoding Encoding { get => throw null; }
            public System.Xml.EntityHandling EntityHandling { get => throw null; set => throw null; }
            public override string GetAttribute(string name) => throw null;
            public override string GetAttribute(string localName, string namespaceURI) => throw null;
            public override string GetAttribute(int i) => throw null;
            System.Collections.Generic.IDictionary<string, string> System.Xml.IXmlNamespaceResolver.GetNamespacesInScope(System.Xml.XmlNamespaceScope scope) => throw null;
            public bool HasLineInfo() => throw null;
            public override bool HasValue { get => throw null; }
            public override bool IsDefault { get => throw null; }
            public override bool IsEmptyElement { get => throw null; }
            public int LineNumber { get => throw null; }
            public int LinePosition { get => throw null; }
            public override string LocalName { get => throw null; }
            string System.Xml.IXmlNamespaceResolver.LookupNamespace(string prefix) => throw null;
            public override string LookupNamespace(string prefix) => throw null;
            string System.Xml.IXmlNamespaceResolver.LookupPrefix(string namespaceName) => throw null;
            public override void MoveToAttribute(int i) => throw null;
            public override bool MoveToAttribute(string name) => throw null;
            public override bool MoveToAttribute(string localName, string namespaceURI) => throw null;
            public override bool MoveToElement() => throw null;
            public override bool MoveToFirstAttribute() => throw null;
            public override bool MoveToNextAttribute() => throw null;
            public override string Name { get => throw null; }
            public override System.Xml.XmlNameTable NameTable { get => throw null; }
            public override string NamespaceURI { get => throw null; }
            public bool Namespaces { get => throw null; set => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override string Prefix { get => throw null; }
            public override System.Char QuoteChar { get => throw null; }
            public override bool Read() => throw null;
            public override bool ReadAttributeValue() => throw null;
            public override int ReadContentAsBase64(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadContentAsBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadElementContentAsBase64(System.Byte[] buffer, int index, int count) => throw null;
            public override int ReadElementContentAsBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public override System.Xml.ReadState ReadState { get => throw null; }
            public override string ReadString() => throw null;
            public object ReadTypedValue() => throw null;
            public System.Xml.XmlReader Reader { get => throw null; }
            public override void ResolveEntity() => throw null;
            public object SchemaType { get => throw null; }
            public System.Xml.Schema.XmlSchemaCollection Schemas { get => throw null; }
            public event System.Xml.Schema.ValidationEventHandler ValidationEventHandler;
            public System.Xml.ValidationType ValidationType { get => throw null; set => throw null; }
            public override string Value { get => throw null; }
            public override string XmlLang { get => throw null; }
            public System.Xml.XmlResolver XmlResolver { set => throw null; }
            public override System.Xml.XmlSpace XmlSpace { get => throw null; }
            public XmlValidatingReader(string xmlFragment, System.Xml.XmlNodeType fragType, System.Xml.XmlParserContext context) => throw null;
            public XmlValidatingReader(System.Xml.XmlReader reader) => throw null;
            public XmlValidatingReader(System.IO.Stream xmlFragment, System.Xml.XmlNodeType fragType, System.Xml.XmlParserContext context) => throw null;
        }

        // Generated from `System.Xml.XmlWhitespace` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlWhitespace : System.Xml.XmlCharacterData
        {
            public override System.Xml.XmlNode CloneNode(bool deep) => throw null;
            public override string LocalName { get => throw null; }
            public override string Name { get => throw null; }
            public override System.Xml.XmlNodeType NodeType { get => throw null; }
            public override System.Xml.XmlNode ParentNode { get => throw null; }
            public override System.Xml.XmlNode PreviousText { get => throw null; }
            public override string Value { get => throw null; set => throw null; }
            public override void WriteContentTo(System.Xml.XmlWriter w) => throw null;
            public override void WriteTo(System.Xml.XmlWriter w) => throw null;
            protected internal XmlWhitespace(string strData, System.Xml.XmlDocument doc) : base(default(string), default(System.Xml.XmlDocument)) => throw null;
        }

        // Generated from `System.Xml.XmlWriter` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public abstract class XmlWriter : System.IDisposable, System.IAsyncDisposable
        {
            public virtual void Close() => throw null;
            public static System.Xml.XmlWriter Create(string outputFileName, System.Xml.XmlWriterSettings settings) => throw null;
            public static System.Xml.XmlWriter Create(string outputFileName) => throw null;
            public static System.Xml.XmlWriter Create(System.Xml.XmlWriter output, System.Xml.XmlWriterSettings settings) => throw null;
            public static System.Xml.XmlWriter Create(System.Xml.XmlWriter output) => throw null;
            public static System.Xml.XmlWriter Create(System.Text.StringBuilder output, System.Xml.XmlWriterSettings settings) => throw null;
            public static System.Xml.XmlWriter Create(System.Text.StringBuilder output) => throw null;
            public static System.Xml.XmlWriter Create(System.IO.TextWriter output, System.Xml.XmlWriterSettings settings) => throw null;
            public static System.Xml.XmlWriter Create(System.IO.TextWriter output) => throw null;
            public static System.Xml.XmlWriter Create(System.IO.Stream output, System.Xml.XmlWriterSettings settings) => throw null;
            public static System.Xml.XmlWriter Create(System.IO.Stream output) => throw null;
            public void Dispose() => throw null;
            protected virtual void Dispose(bool disposing) => throw null;
            public System.Threading.Tasks.ValueTask DisposeAsync() => throw null;
            protected virtual System.Threading.Tasks.ValueTask DisposeAsyncCore() => throw null;
            public abstract void Flush();
            public virtual System.Threading.Tasks.Task FlushAsync() => throw null;
            public abstract string LookupPrefix(string ns);
            public virtual System.Xml.XmlWriterSettings Settings { get => throw null; }
            public void WriteAttributeString(string prefix, string localName, string ns, string value) => throw null;
            public void WriteAttributeString(string localName, string value) => throw null;
            public void WriteAttributeString(string localName, string ns, string value) => throw null;
            public System.Threading.Tasks.Task WriteAttributeStringAsync(string prefix, string localName, string ns, string value) => throw null;
            public virtual void WriteAttributes(System.Xml.XmlReader reader, bool defattr) => throw null;
            public virtual System.Threading.Tasks.Task WriteAttributesAsync(System.Xml.XmlReader reader, bool defattr) => throw null;
            public abstract void WriteBase64(System.Byte[] buffer, int index, int count);
            public virtual System.Threading.Tasks.Task WriteBase64Async(System.Byte[] buffer, int index, int count) => throw null;
            public virtual void WriteBinHex(System.Byte[] buffer, int index, int count) => throw null;
            public virtual System.Threading.Tasks.Task WriteBinHexAsync(System.Byte[] buffer, int index, int count) => throw null;
            public abstract void WriteCData(string text);
            public virtual System.Threading.Tasks.Task WriteCDataAsync(string text) => throw null;
            public abstract void WriteCharEntity(System.Char ch);
            public virtual System.Threading.Tasks.Task WriteCharEntityAsync(System.Char ch) => throw null;
            public abstract void WriteChars(System.Char[] buffer, int index, int count);
            public virtual System.Threading.Tasks.Task WriteCharsAsync(System.Char[] buffer, int index, int count) => throw null;
            public abstract void WriteComment(string text);
            public virtual System.Threading.Tasks.Task WriteCommentAsync(string text) => throw null;
            public abstract void WriteDocType(string name, string pubid, string sysid, string subset);
            public virtual System.Threading.Tasks.Task WriteDocTypeAsync(string name, string pubid, string sysid, string subset) => throw null;
            public void WriteElementString(string prefix, string localName, string ns, string value) => throw null;
            public void WriteElementString(string localName, string value) => throw null;
            public void WriteElementString(string localName, string ns, string value) => throw null;
            public System.Threading.Tasks.Task WriteElementStringAsync(string prefix, string localName, string ns, string value) => throw null;
            public abstract void WriteEndAttribute();
            protected internal virtual System.Threading.Tasks.Task WriteEndAttributeAsync() => throw null;
            public abstract void WriteEndDocument();
            public virtual System.Threading.Tasks.Task WriteEndDocumentAsync() => throw null;
            public abstract void WriteEndElement();
            public virtual System.Threading.Tasks.Task WriteEndElementAsync() => throw null;
            public abstract void WriteEntityRef(string name);
            public virtual System.Threading.Tasks.Task WriteEntityRefAsync(string name) => throw null;
            public abstract void WriteFullEndElement();
            public virtual System.Threading.Tasks.Task WriteFullEndElementAsync() => throw null;
            public virtual void WriteName(string name) => throw null;
            public virtual System.Threading.Tasks.Task WriteNameAsync(string name) => throw null;
            public virtual void WriteNmToken(string name) => throw null;
            public virtual System.Threading.Tasks.Task WriteNmTokenAsync(string name) => throw null;
            public virtual void WriteNode(System.Xml.XmlReader reader, bool defattr) => throw null;
            public virtual void WriteNode(System.Xml.XPath.XPathNavigator navigator, bool defattr) => throw null;
            public virtual System.Threading.Tasks.Task WriteNodeAsync(System.Xml.XmlReader reader, bool defattr) => throw null;
            public virtual System.Threading.Tasks.Task WriteNodeAsync(System.Xml.XPath.XPathNavigator navigator, bool defattr) => throw null;
            public abstract void WriteProcessingInstruction(string name, string text);
            public virtual System.Threading.Tasks.Task WriteProcessingInstructionAsync(string name, string text) => throw null;
            public virtual void WriteQualifiedName(string localName, string ns) => throw null;
            public virtual System.Threading.Tasks.Task WriteQualifiedNameAsync(string localName, string ns) => throw null;
            public abstract void WriteRaw(string data);
            public abstract void WriteRaw(System.Char[] buffer, int index, int count);
            public virtual System.Threading.Tasks.Task WriteRawAsync(string data) => throw null;
            public virtual System.Threading.Tasks.Task WriteRawAsync(System.Char[] buffer, int index, int count) => throw null;
            public void WriteStartAttribute(string localName, string ns) => throw null;
            public void WriteStartAttribute(string localName) => throw null;
            public abstract void WriteStartAttribute(string prefix, string localName, string ns);
            protected internal virtual System.Threading.Tasks.Task WriteStartAttributeAsync(string prefix, string localName, string ns) => throw null;
            public abstract void WriteStartDocument(bool standalone);
            public abstract void WriteStartDocument();
            public virtual System.Threading.Tasks.Task WriteStartDocumentAsync(bool standalone) => throw null;
            public virtual System.Threading.Tasks.Task WriteStartDocumentAsync() => throw null;
            public void WriteStartElement(string localName, string ns) => throw null;
            public void WriteStartElement(string localName) => throw null;
            public abstract void WriteStartElement(string prefix, string localName, string ns);
            public virtual System.Threading.Tasks.Task WriteStartElementAsync(string prefix, string localName, string ns) => throw null;
            public abstract System.Xml.WriteState WriteState { get; }
            public abstract void WriteString(string text);
            public virtual System.Threading.Tasks.Task WriteStringAsync(string text) => throw null;
            public abstract void WriteSurrogateCharEntity(System.Char lowChar, System.Char highChar);
            public virtual System.Threading.Tasks.Task WriteSurrogateCharEntityAsync(System.Char lowChar, System.Char highChar) => throw null;
            public virtual void WriteValue(string value) => throw null;
            public virtual void WriteValue(object value) => throw null;
            public virtual void WriteValue(int value) => throw null;
            public virtual void WriteValue(float value) => throw null;
            public virtual void WriteValue(double value) => throw null;
            public virtual void WriteValue(bool value) => throw null;
            public virtual void WriteValue(System.Int64 value) => throw null;
            public virtual void WriteValue(System.Decimal value) => throw null;
            public virtual void WriteValue(System.DateTimeOffset value) => throw null;
            public virtual void WriteValue(System.DateTime value) => throw null;
            public abstract void WriteWhitespace(string ws);
            public virtual System.Threading.Tasks.Task WriteWhitespaceAsync(string ws) => throw null;
            public virtual string XmlLang { get => throw null; }
            public virtual System.Xml.XmlSpace XmlSpace { get => throw null; }
            protected XmlWriter() => throw null;
        }

        // Generated from `System.Xml.XmlWriterSettings` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
        public class XmlWriterSettings
        {
            public bool Async { get => throw null; set => throw null; }
            public bool CheckCharacters { get => throw null; set => throw null; }
            public System.Xml.XmlWriterSettings Clone() => throw null;
            public bool CloseOutput { get => throw null; set => throw null; }
            public System.Xml.ConformanceLevel ConformanceLevel { get => throw null; set => throw null; }
            public bool DoNotEscapeUriAttributes { get => throw null; set => throw null; }
            public System.Text.Encoding Encoding { get => throw null; set => throw null; }
            public bool Indent { get => throw null; set => throw null; }
            public string IndentChars { get => throw null; set => throw null; }
            public System.Xml.NamespaceHandling NamespaceHandling { get => throw null; set => throw null; }
            public string NewLineChars { get => throw null; set => throw null; }
            public System.Xml.NewLineHandling NewLineHandling { get => throw null; set => throw null; }
            public bool NewLineOnAttributes { get => throw null; set => throw null; }
            public bool OmitXmlDeclaration { get => throw null; set => throw null; }
            public System.Xml.XmlOutputMethod OutputMethod { get => throw null; }
            public void Reset() => throw null;
            public bool WriteEndDocumentOnClose { get => throw null; set => throw null; }
            public XmlWriterSettings() => throw null;
        }

        namespace Resolvers
        {
            // Generated from `System.Xml.Resolvers.XmlKnownDtds` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            [System.Flags]
            public enum XmlKnownDtds
            {
                All,
                None,
                Rss091,
                Xhtml10,
            }

            // Generated from `System.Xml.Resolvers.XmlPreloadedResolver` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlPreloadedResolver : System.Xml.XmlResolver
            {
                public void Add(System.Uri uri, string value) => throw null;
                public void Add(System.Uri uri, System.IO.Stream value) => throw null;
                public void Add(System.Uri uri, System.Byte[] value, int offset, int count) => throw null;
                public void Add(System.Uri uri, System.Byte[] value) => throw null;
                public override System.Net.ICredentials Credentials { set => throw null; }
                public override object GetEntity(System.Uri absoluteUri, string role, System.Type ofObjectToReturn) => throw null;
                public override System.Threading.Tasks.Task<object> GetEntityAsync(System.Uri absoluteUri, string role, System.Type ofObjectToReturn) => throw null;
                public System.Collections.Generic.IEnumerable<System.Uri> PreloadedUris { get => throw null; }
                public void Remove(System.Uri uri) => throw null;
                public override System.Uri ResolveUri(System.Uri baseUri, string relativeUri) => throw null;
                public override bool SupportsType(System.Uri absoluteUri, System.Type type) => throw null;
                public XmlPreloadedResolver(System.Xml.XmlResolver fallbackResolver, System.Xml.Resolvers.XmlKnownDtds preloadedDtds, System.Collections.Generic.IEqualityComparer<System.Uri> uriComparer) => throw null;
                public XmlPreloadedResolver(System.Xml.XmlResolver fallbackResolver, System.Xml.Resolvers.XmlKnownDtds preloadedDtds) => throw null;
                public XmlPreloadedResolver(System.Xml.XmlResolver fallbackResolver) => throw null;
                public XmlPreloadedResolver(System.Xml.Resolvers.XmlKnownDtds preloadedDtds) => throw null;
                public XmlPreloadedResolver() => throw null;
            }

        }
        namespace Schema
        {
            // Generated from `System.Xml.Schema.IXmlSchemaInfo` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public interface IXmlSchemaInfo
            {
                bool IsDefault { get; }
                bool IsNil { get; }
                System.Xml.Schema.XmlSchemaSimpleType MemberType { get; }
                System.Xml.Schema.XmlSchemaAttribute SchemaAttribute { get; }
                System.Xml.Schema.XmlSchemaElement SchemaElement { get; }
                System.Xml.Schema.XmlSchemaType SchemaType { get; }
                System.Xml.Schema.XmlSchemaValidity Validity { get; }
            }

            // Generated from `System.Xml.Schema.ValidationEventArgs` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class ValidationEventArgs : System.EventArgs
            {
                public System.Xml.Schema.XmlSchemaException Exception { get => throw null; }
                public string Message { get => throw null; }
                public System.Xml.Schema.XmlSeverityType Severity { get => throw null; }
            }

            // Generated from `System.Xml.Schema.ValidationEventHandler` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public delegate void ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e);

            // Generated from `System.Xml.Schema.XmlAtomicValue` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlAtomicValue : System.Xml.XPath.XPathItem, System.ICloneable
            {
                public System.Xml.Schema.XmlAtomicValue Clone() => throw null;
                object System.ICloneable.Clone() => throw null;
                public override bool IsNode { get => throw null; }
                public override string ToString() => throw null;
                public override object TypedValue { get => throw null; }
                public override string Value { get => throw null; }
                public override object ValueAs(System.Type type, System.Xml.IXmlNamespaceResolver nsResolver) => throw null;
                public override bool ValueAsBoolean { get => throw null; }
                public override System.DateTime ValueAsDateTime { get => throw null; }
                public override double ValueAsDouble { get => throw null; }
                public override int ValueAsInt { get => throw null; }
                public override System.Int64 ValueAsLong { get => throw null; }
                public override System.Type ValueType { get => throw null; }
                public override System.Xml.Schema.XmlSchemaType XmlType { get => throw null; }
            }

            // Generated from `System.Xml.Schema.XmlSchema` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchema : System.Xml.Schema.XmlSchemaObject
            {
                public System.Xml.Schema.XmlSchemaForm AttributeFormDefault { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable AttributeGroups { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable Attributes { get => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod BlockDefault { get => throw null; set => throw null; }
                public void Compile(System.Xml.Schema.ValidationEventHandler validationEventHandler, System.Xml.XmlResolver resolver) => throw null;
                public void Compile(System.Xml.Schema.ValidationEventHandler validationEventHandler) => throw null;
                public System.Xml.Schema.XmlSchemaForm ElementFormDefault { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable Elements { get => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod FinalDefault { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable Groups { get => throw null; }
                public string Id { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Includes { get => throw null; }
                public const string InstanceNamespace = default;
                public bool IsCompiled { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Items { get => throw null; }
                public const string Namespace = default;
                public System.Xml.Schema.XmlSchemaObjectTable Notations { get => throw null; }
                public static System.Xml.Schema.XmlSchema Read(System.Xml.XmlReader reader, System.Xml.Schema.ValidationEventHandler validationEventHandler) => throw null;
                public static System.Xml.Schema.XmlSchema Read(System.IO.TextReader reader, System.Xml.Schema.ValidationEventHandler validationEventHandler) => throw null;
                public static System.Xml.Schema.XmlSchema Read(System.IO.Stream stream, System.Xml.Schema.ValidationEventHandler validationEventHandler) => throw null;
                public System.Xml.Schema.XmlSchemaObjectTable SchemaTypes { get => throw null; }
                public string TargetNamespace { get => throw null; set => throw null; }
                public System.Xml.XmlAttribute[] UnhandledAttributes { get => throw null; set => throw null; }
                public string Version { get => throw null; set => throw null; }
                public void Write(System.Xml.XmlWriter writer, System.Xml.XmlNamespaceManager namespaceManager) => throw null;
                public void Write(System.Xml.XmlWriter writer) => throw null;
                public void Write(System.IO.TextWriter writer, System.Xml.XmlNamespaceManager namespaceManager) => throw null;
                public void Write(System.IO.TextWriter writer) => throw null;
                public void Write(System.IO.Stream stream, System.Xml.XmlNamespaceManager namespaceManager) => throw null;
                public void Write(System.IO.Stream stream) => throw null;
                public XmlSchema() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAll` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAll : System.Xml.Schema.XmlSchemaGroupBase
            {
                public override System.Xml.Schema.XmlSchemaObjectCollection Items { get => throw null; }
                public XmlSchemaAll() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAnnotated` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAnnotated : System.Xml.Schema.XmlSchemaObject
            {
                public System.Xml.Schema.XmlSchemaAnnotation Annotation { get => throw null; set => throw null; }
                public string Id { get => throw null; set => throw null; }
                public System.Xml.XmlAttribute[] UnhandledAttributes { get => throw null; set => throw null; }
                public XmlSchemaAnnotated() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAnnotation` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAnnotation : System.Xml.Schema.XmlSchemaObject
            {
                public string Id { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Items { get => throw null; }
                public System.Xml.XmlAttribute[] UnhandledAttributes { get => throw null; set => throw null; }
                public XmlSchemaAnnotation() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAny` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAny : System.Xml.Schema.XmlSchemaParticle
            {
                public string Namespace { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaContentProcessing ProcessContents { get => throw null; set => throw null; }
                public XmlSchemaAny() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAnyAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAnyAttribute : System.Xml.Schema.XmlSchemaAnnotated
            {
                public string Namespace { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaContentProcessing ProcessContents { get => throw null; set => throw null; }
                public XmlSchemaAnyAttribute() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAppInfo` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAppInfo : System.Xml.Schema.XmlSchemaObject
            {
                public System.Xml.XmlNode[] Markup { get => throw null; set => throw null; }
                public string Source { get => throw null; set => throw null; }
                public XmlSchemaAppInfo() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAttribute : System.Xml.Schema.XmlSchemaAnnotated
            {
                public System.Xml.Schema.XmlSchemaSimpleType AttributeSchemaType { get => throw null; }
                public object AttributeType { get => throw null; }
                public string DefaultValue { get => throw null; set => throw null; }
                public string FixedValue { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaForm Form { get => throw null; set => throw null; }
                public string Name { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName QualifiedName { get => throw null; }
                public System.Xml.XmlQualifiedName RefName { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaSimpleType SchemaType { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName SchemaTypeName { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaUse Use { get => throw null; set => throw null; }
                public XmlSchemaAttribute() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAttributeGroup` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAttributeGroup : System.Xml.Schema.XmlSchemaAnnotated
            {
                public System.Xml.Schema.XmlSchemaAnyAttribute AnyAttribute { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Attributes { get => throw null; }
                public string Name { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName QualifiedName { get => throw null; }
                public System.Xml.Schema.XmlSchemaAttributeGroup RedefinedAttributeGroup { get => throw null; }
                public XmlSchemaAttributeGroup() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaAttributeGroupRef` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaAttributeGroupRef : System.Xml.Schema.XmlSchemaAnnotated
            {
                public System.Xml.XmlQualifiedName RefName { get => throw null; set => throw null; }
                public XmlSchemaAttributeGroupRef() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaChoice` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaChoice : System.Xml.Schema.XmlSchemaGroupBase
            {
                public override System.Xml.Schema.XmlSchemaObjectCollection Items { get => throw null; }
                public XmlSchemaChoice() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaCollection` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaCollection : System.Collections.IEnumerable, System.Collections.ICollection
            {
                public void Add(System.Xml.Schema.XmlSchemaCollection schema) => throw null;
                public System.Xml.Schema.XmlSchema Add(string ns, string uri) => throw null;
                public System.Xml.Schema.XmlSchema Add(string ns, System.Xml.XmlReader reader, System.Xml.XmlResolver resolver) => throw null;
                public System.Xml.Schema.XmlSchema Add(string ns, System.Xml.XmlReader reader) => throw null;
                public System.Xml.Schema.XmlSchema Add(System.Xml.Schema.XmlSchema schema, System.Xml.XmlResolver resolver) => throw null;
                public System.Xml.Schema.XmlSchema Add(System.Xml.Schema.XmlSchema schema) => throw null;
                public bool Contains(string ns) => throw null;
                public bool Contains(System.Xml.Schema.XmlSchema schema) => throw null;
                void System.Collections.ICollection.CopyTo(System.Array array, int index) => throw null;
                public void CopyTo(System.Xml.Schema.XmlSchema[] array, int index) => throw null;
                public int Count { get => throw null; }
                int System.Collections.ICollection.Count { get => throw null; }
                public System.Xml.Schema.XmlSchemaCollectionEnumerator GetEnumerator() => throw null;
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => throw null;
                bool System.Collections.ICollection.IsSynchronized { get => throw null; }
                public System.Xml.Schema.XmlSchema this[string ns] { get => throw null; }
                public System.Xml.XmlNameTable NameTable { get => throw null; }
                object System.Collections.ICollection.SyncRoot { get => throw null; }
                public event System.Xml.Schema.ValidationEventHandler ValidationEventHandler;
                public XmlSchemaCollection(System.Xml.XmlNameTable nametable) => throw null;
                public XmlSchemaCollection() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaCollectionEnumerator` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaCollectionEnumerator : System.Collections.IEnumerator
            {
                public System.Xml.Schema.XmlSchema Current { get => throw null; }
                object System.Collections.IEnumerator.Current { get => throw null; }
                public bool MoveNext() => throw null;
                bool System.Collections.IEnumerator.MoveNext() => throw null;
                void System.Collections.IEnumerator.Reset() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaCompilationSettings` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaCompilationSettings
            {
                public bool EnableUpaCheck { get => throw null; set => throw null; }
                public XmlSchemaCompilationSettings() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaComplexContent` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaComplexContent : System.Xml.Schema.XmlSchemaContentModel
            {
                public override System.Xml.Schema.XmlSchemaContent Content { get => throw null; set => throw null; }
                public bool IsMixed { get => throw null; set => throw null; }
                public XmlSchemaComplexContent() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaComplexContentExtension` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaComplexContentExtension : System.Xml.Schema.XmlSchemaContent
            {
                public System.Xml.Schema.XmlSchemaAnyAttribute AnyAttribute { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Attributes { get => throw null; }
                public System.Xml.XmlQualifiedName BaseTypeName { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaParticle Particle { get => throw null; set => throw null; }
                public XmlSchemaComplexContentExtension() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaComplexContentRestriction` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaComplexContentRestriction : System.Xml.Schema.XmlSchemaContent
            {
                public System.Xml.Schema.XmlSchemaAnyAttribute AnyAttribute { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Attributes { get => throw null; }
                public System.Xml.XmlQualifiedName BaseTypeName { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaParticle Particle { get => throw null; set => throw null; }
                public XmlSchemaComplexContentRestriction() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaComplexType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaComplexType : System.Xml.Schema.XmlSchemaType
            {
                public System.Xml.Schema.XmlSchemaAnyAttribute AnyAttribute { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable AttributeUses { get => throw null; }
                public System.Xml.Schema.XmlSchemaAnyAttribute AttributeWildcard { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Attributes { get => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod Block { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod BlockResolved { get => throw null; }
                public System.Xml.Schema.XmlSchemaContentModel ContentModel { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaContentType ContentType { get => throw null; }
                public System.Xml.Schema.XmlSchemaParticle ContentTypeParticle { get => throw null; }
                public bool IsAbstract { get => throw null; set => throw null; }
                public override bool IsMixed { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaParticle Particle { get => throw null; set => throw null; }
                public XmlSchemaComplexType() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaContent` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaContent : System.Xml.Schema.XmlSchemaAnnotated
            {
                protected XmlSchemaContent() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaContentModel` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaContentModel : System.Xml.Schema.XmlSchemaAnnotated
            {
                public abstract System.Xml.Schema.XmlSchemaContent Content { get; set; }
                protected XmlSchemaContentModel() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaContentProcessing` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlSchemaContentProcessing
            {
                Lax,
                None,
                Skip,
                Strict,
            }

            // Generated from `System.Xml.Schema.XmlSchemaContentType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlSchemaContentType
            {
                ElementOnly,
                Empty,
                Mixed,
                TextOnly,
            }

            // Generated from `System.Xml.Schema.XmlSchemaDatatype` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaDatatype
            {
                public virtual object ChangeType(object value, System.Type targetType, System.Xml.IXmlNamespaceResolver namespaceResolver) => throw null;
                public virtual object ChangeType(object value, System.Type targetType) => throw null;
                public virtual bool IsDerivedFrom(System.Xml.Schema.XmlSchemaDatatype datatype) => throw null;
                public abstract object ParseValue(string s, System.Xml.XmlNameTable nameTable, System.Xml.IXmlNamespaceResolver nsmgr);
                public abstract System.Xml.XmlTokenizedType TokenizedType { get; }
                public virtual System.Xml.Schema.XmlTypeCode TypeCode { get => throw null; }
                public abstract System.Type ValueType { get; }
                public virtual System.Xml.Schema.XmlSchemaDatatypeVariety Variety { get => throw null; }
            }

            // Generated from `System.Xml.Schema.XmlSchemaDatatypeVariety` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlSchemaDatatypeVariety
            {
                Atomic,
                List,
                Union,
            }

            // Generated from `System.Xml.Schema.XmlSchemaDerivationMethod` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            [System.Flags]
            public enum XmlSchemaDerivationMethod
            {
                All,
                Empty,
                Extension,
                List,
                None,
                Restriction,
                Substitution,
                Union,
            }

            // Generated from `System.Xml.Schema.XmlSchemaDocumentation` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaDocumentation : System.Xml.Schema.XmlSchemaObject
            {
                public string Language { get => throw null; set => throw null; }
                public System.Xml.XmlNode[] Markup { get => throw null; set => throw null; }
                public string Source { get => throw null; set => throw null; }
                public XmlSchemaDocumentation() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaElement` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaElement : System.Xml.Schema.XmlSchemaParticle
            {
                public System.Xml.Schema.XmlSchemaDerivationMethod Block { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod BlockResolved { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Constraints { get => throw null; }
                public string DefaultValue { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaType ElementSchemaType { get => throw null; }
                public object ElementType { get => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod Final { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod FinalResolved { get => throw null; }
                public string FixedValue { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaForm Form { get => throw null; set => throw null; }
                public bool IsAbstract { get => throw null; set => throw null; }
                public bool IsNillable { get => throw null; set => throw null; }
                public string Name { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName QualifiedName { get => throw null; }
                public System.Xml.XmlQualifiedName RefName { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaType SchemaType { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName SchemaTypeName { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName SubstitutionGroup { get => throw null; set => throw null; }
                public XmlSchemaElement() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaEnumerationFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaEnumerationFacet : System.Xml.Schema.XmlSchemaFacet
            {
                public XmlSchemaEnumerationFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaException` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaException : System.SystemException
            {
                public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
                public int LineNumber { get => throw null; }
                public int LinePosition { get => throw null; }
                public override string Message { get => throw null; }
                public System.Xml.Schema.XmlSchemaObject SourceSchemaObject { get => throw null; }
                public string SourceUri { get => throw null; }
                public XmlSchemaException(string message, System.Exception innerException, int lineNumber, int linePosition) => throw null;
                public XmlSchemaException(string message, System.Exception innerException) => throw null;
                public XmlSchemaException(string message) => throw null;
                public XmlSchemaException() => throw null;
                protected XmlSchemaException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaExternal` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaExternal : System.Xml.Schema.XmlSchemaObject
            {
                public string Id { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchema Schema { get => throw null; set => throw null; }
                public string SchemaLocation { get => throw null; set => throw null; }
                public System.Xml.XmlAttribute[] UnhandledAttributes { get => throw null; set => throw null; }
                protected XmlSchemaExternal() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaFacet : System.Xml.Schema.XmlSchemaAnnotated
            {
                public virtual bool IsFixed { get => throw null; set => throw null; }
                public string Value { get => throw null; set => throw null; }
                protected XmlSchemaFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaForm` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlSchemaForm
            {
                None,
                Qualified,
                Unqualified,
            }

            // Generated from `System.Xml.Schema.XmlSchemaFractionDigitsFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaFractionDigitsFacet : System.Xml.Schema.XmlSchemaNumericFacet
            {
                public XmlSchemaFractionDigitsFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaGroup` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaGroup : System.Xml.Schema.XmlSchemaAnnotated
            {
                public string Name { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaGroupBase Particle { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName QualifiedName { get => throw null; }
                public XmlSchemaGroup() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaGroupBase` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaGroupBase : System.Xml.Schema.XmlSchemaParticle
            {
                public abstract System.Xml.Schema.XmlSchemaObjectCollection Items { get; }
                internal XmlSchemaGroupBase() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaGroupRef` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaGroupRef : System.Xml.Schema.XmlSchemaParticle
            {
                public System.Xml.Schema.XmlSchemaGroupBase Particle { get => throw null; }
                public System.Xml.XmlQualifiedName RefName { get => throw null; set => throw null; }
                public XmlSchemaGroupRef() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaIdentityConstraint` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaIdentityConstraint : System.Xml.Schema.XmlSchemaAnnotated
            {
                public System.Xml.Schema.XmlSchemaObjectCollection Fields { get => throw null; }
                public string Name { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName QualifiedName { get => throw null; }
                public System.Xml.Schema.XmlSchemaXPath Selector { get => throw null; set => throw null; }
                public XmlSchemaIdentityConstraint() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaImport` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaImport : System.Xml.Schema.XmlSchemaExternal
            {
                public System.Xml.Schema.XmlSchemaAnnotation Annotation { get => throw null; set => throw null; }
                public string Namespace { get => throw null; set => throw null; }
                public XmlSchemaImport() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaInclude` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaInclude : System.Xml.Schema.XmlSchemaExternal
            {
                public System.Xml.Schema.XmlSchemaAnnotation Annotation { get => throw null; set => throw null; }
                public XmlSchemaInclude() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaInference` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaInference
            {
                public System.Xml.Schema.XmlSchemaSet InferSchema(System.Xml.XmlReader instanceDocument, System.Xml.Schema.XmlSchemaSet schemas) => throw null;
                public System.Xml.Schema.XmlSchemaSet InferSchema(System.Xml.XmlReader instanceDocument) => throw null;
                // Generated from `System.Xml.Schema.XmlSchemaInference+InferenceOption` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
                public enum InferenceOption
                {
                    Relaxed,
                    Restricted,
                }


                public System.Xml.Schema.XmlSchemaInference.InferenceOption Occurrence { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaInference.InferenceOption TypeInference { get => throw null; set => throw null; }
                public XmlSchemaInference() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaInferenceException` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaInferenceException : System.Xml.Schema.XmlSchemaException
            {
                public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
                public XmlSchemaInferenceException(string message, System.Exception innerException, int lineNumber, int linePosition) => throw null;
                public XmlSchemaInferenceException(string message, System.Exception innerException) => throw null;
                public XmlSchemaInferenceException(string message) => throw null;
                public XmlSchemaInferenceException() => throw null;
                protected XmlSchemaInferenceException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaInfo` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaInfo : System.Xml.Schema.IXmlSchemaInfo
            {
                public System.Xml.Schema.XmlSchemaContentType ContentType { get => throw null; set => throw null; }
                public bool IsDefault { get => throw null; set => throw null; }
                public bool IsNil { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaSimpleType MemberType { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaAttribute SchemaAttribute { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaElement SchemaElement { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaType SchemaType { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaValidity Validity { get => throw null; set => throw null; }
                public XmlSchemaInfo() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaKey` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaKey : System.Xml.Schema.XmlSchemaIdentityConstraint
            {
                public XmlSchemaKey() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaKeyref` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaKeyref : System.Xml.Schema.XmlSchemaIdentityConstraint
            {
                public System.Xml.XmlQualifiedName Refer { get => throw null; set => throw null; }
                public XmlSchemaKeyref() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaLengthFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaLengthFacet : System.Xml.Schema.XmlSchemaNumericFacet
            {
                public XmlSchemaLengthFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaMaxExclusiveFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaMaxExclusiveFacet : System.Xml.Schema.XmlSchemaFacet
            {
                public XmlSchemaMaxExclusiveFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaMaxInclusiveFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaMaxInclusiveFacet : System.Xml.Schema.XmlSchemaFacet
            {
                public XmlSchemaMaxInclusiveFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaMaxLengthFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaMaxLengthFacet : System.Xml.Schema.XmlSchemaNumericFacet
            {
                public XmlSchemaMaxLengthFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaMinExclusiveFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaMinExclusiveFacet : System.Xml.Schema.XmlSchemaFacet
            {
                public XmlSchemaMinExclusiveFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaMinInclusiveFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaMinInclusiveFacet : System.Xml.Schema.XmlSchemaFacet
            {
                public XmlSchemaMinInclusiveFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaMinLengthFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaMinLengthFacet : System.Xml.Schema.XmlSchemaNumericFacet
            {
                public XmlSchemaMinLengthFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaNotation` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaNotation : System.Xml.Schema.XmlSchemaAnnotated
            {
                public string Name { get => throw null; set => throw null; }
                public string Public { get => throw null; set => throw null; }
                public string System { get => throw null; set => throw null; }
                public XmlSchemaNotation() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaNumericFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaNumericFacet : System.Xml.Schema.XmlSchemaFacet
            {
                protected XmlSchemaNumericFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaObject` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaObject
            {
                public int LineNumber { get => throw null; set => throw null; }
                public int LinePosition { get => throw null; set => throw null; }
                public System.Xml.Serialization.XmlSerializerNamespaces Namespaces { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObject Parent { get => throw null; set => throw null; }
                public string SourceUri { get => throw null; set => throw null; }
                protected XmlSchemaObject() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaObjectCollection` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaObjectCollection : System.Collections.CollectionBase
            {
                public int Add(System.Xml.Schema.XmlSchemaObject item) => throw null;
                public bool Contains(System.Xml.Schema.XmlSchemaObject item) => throw null;
                public void CopyTo(System.Xml.Schema.XmlSchemaObject[] array, int index) => throw null;
                public System.Xml.Schema.XmlSchemaObjectEnumerator GetEnumerator() => throw null;
                public int IndexOf(System.Xml.Schema.XmlSchemaObject item) => throw null;
                public void Insert(int index, System.Xml.Schema.XmlSchemaObject item) => throw null;
                public virtual System.Xml.Schema.XmlSchemaObject this[int index] { get => throw null; set => throw null; }
                protected override void OnClear() => throw null;
                protected override void OnInsert(int index, object item) => throw null;
                protected override void OnRemove(int index, object item) => throw null;
                protected override void OnSet(int index, object oldValue, object newValue) => throw null;
                public void Remove(System.Xml.Schema.XmlSchemaObject item) => throw null;
                public XmlSchemaObjectCollection(System.Xml.Schema.XmlSchemaObject parent) => throw null;
                public XmlSchemaObjectCollection() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaObjectEnumerator` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaObjectEnumerator : System.Collections.IEnumerator
            {
                public System.Xml.Schema.XmlSchemaObject Current { get => throw null; }
                object System.Collections.IEnumerator.Current { get => throw null; }
                public bool MoveNext() => throw null;
                bool System.Collections.IEnumerator.MoveNext() => throw null;
                void System.Collections.IEnumerator.Reset() => throw null;
                public void Reset() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaObjectTable` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaObjectTable
            {
                public bool Contains(System.Xml.XmlQualifiedName name) => throw null;
                public int Count { get => throw null; }
                public System.Collections.IDictionaryEnumerator GetEnumerator() => throw null;
                public System.Xml.Schema.XmlSchemaObject this[System.Xml.XmlQualifiedName name] { get => throw null; }
                public System.Collections.ICollection Names { get => throw null; }
                public System.Collections.ICollection Values { get => throw null; }
            }

            // Generated from `System.Xml.Schema.XmlSchemaParticle` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaParticle : System.Xml.Schema.XmlSchemaAnnotated
            {
                public System.Decimal MaxOccurs { get => throw null; set => throw null; }
                public string MaxOccursString { get => throw null; set => throw null; }
                public System.Decimal MinOccurs { get => throw null; set => throw null; }
                public string MinOccursString { get => throw null; set => throw null; }
                protected XmlSchemaParticle() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaPatternFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaPatternFacet : System.Xml.Schema.XmlSchemaFacet
            {
                public XmlSchemaPatternFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaRedefine` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaRedefine : System.Xml.Schema.XmlSchemaExternal
            {
                public System.Xml.Schema.XmlSchemaObjectTable AttributeGroups { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable Groups { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Items { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable SchemaTypes { get => throw null; }
                public XmlSchemaRedefine() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSequence` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSequence : System.Xml.Schema.XmlSchemaGroupBase
            {
                public override System.Xml.Schema.XmlSchemaObjectCollection Items { get => throw null; }
                public XmlSchemaSequence() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSet
            {
                public void Add(System.Xml.Schema.XmlSchemaSet schemas) => throw null;
                public System.Xml.Schema.XmlSchema Add(string targetNamespace, string schemaUri) => throw null;
                public System.Xml.Schema.XmlSchema Add(string targetNamespace, System.Xml.XmlReader schemaDocument) => throw null;
                public System.Xml.Schema.XmlSchema Add(System.Xml.Schema.XmlSchema schema) => throw null;
                public System.Xml.Schema.XmlSchemaCompilationSettings CompilationSettings { get => throw null; set => throw null; }
                public void Compile() => throw null;
                public bool Contains(string targetNamespace) => throw null;
                public bool Contains(System.Xml.Schema.XmlSchema schema) => throw null;
                public void CopyTo(System.Xml.Schema.XmlSchema[] schemas, int index) => throw null;
                public int Count { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable GlobalAttributes { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable GlobalElements { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectTable GlobalTypes { get => throw null; }
                public bool IsCompiled { get => throw null; }
                public System.Xml.XmlNameTable NameTable { get => throw null; }
                public System.Xml.Schema.XmlSchema Remove(System.Xml.Schema.XmlSchema schema) => throw null;
                public bool RemoveRecursive(System.Xml.Schema.XmlSchema schemaToRemove) => throw null;
                public System.Xml.Schema.XmlSchema Reprocess(System.Xml.Schema.XmlSchema schema) => throw null;
                public System.Collections.ICollection Schemas(string targetNamespace) => throw null;
                public System.Collections.ICollection Schemas() => throw null;
                public event System.Xml.Schema.ValidationEventHandler ValidationEventHandler;
                public System.Xml.XmlResolver XmlResolver { set => throw null; }
                public XmlSchemaSet(System.Xml.XmlNameTable nameTable) => throw null;
                public XmlSchemaSet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSimpleContent` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSimpleContent : System.Xml.Schema.XmlSchemaContentModel
            {
                public override System.Xml.Schema.XmlSchemaContent Content { get => throw null; set => throw null; }
                public XmlSchemaSimpleContent() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSimpleContentExtension` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSimpleContentExtension : System.Xml.Schema.XmlSchemaContent
            {
                public System.Xml.Schema.XmlSchemaAnyAttribute AnyAttribute { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Attributes { get => throw null; }
                public System.Xml.XmlQualifiedName BaseTypeName { get => throw null; set => throw null; }
                public XmlSchemaSimpleContentExtension() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSimpleContentRestriction` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSimpleContentRestriction : System.Xml.Schema.XmlSchemaContent
            {
                public System.Xml.Schema.XmlSchemaAnyAttribute AnyAttribute { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Attributes { get => throw null; }
                public System.Xml.Schema.XmlSchemaSimpleType BaseType { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName BaseTypeName { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Facets { get => throw null; }
                public XmlSchemaSimpleContentRestriction() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSimpleType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSimpleType : System.Xml.Schema.XmlSchemaType
            {
                public System.Xml.Schema.XmlSchemaSimpleTypeContent Content { get => throw null; set => throw null; }
                public XmlSchemaSimpleType() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSimpleTypeContent` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XmlSchemaSimpleTypeContent : System.Xml.Schema.XmlSchemaAnnotated
            {
                protected XmlSchemaSimpleTypeContent() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSimpleTypeList` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSimpleTypeList : System.Xml.Schema.XmlSchemaSimpleTypeContent
            {
                public System.Xml.Schema.XmlSchemaSimpleType BaseItemType { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaSimpleType ItemType { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName ItemTypeName { get => throw null; set => throw null; }
                public XmlSchemaSimpleTypeList() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSimpleTypeRestriction` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSimpleTypeRestriction : System.Xml.Schema.XmlSchemaSimpleTypeContent
            {
                public System.Xml.Schema.XmlSchemaSimpleType BaseType { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName BaseTypeName { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection Facets { get => throw null; }
                public XmlSchemaSimpleTypeRestriction() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaSimpleTypeUnion` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaSimpleTypeUnion : System.Xml.Schema.XmlSchemaSimpleTypeContent
            {
                public System.Xml.Schema.XmlSchemaSimpleType[] BaseMemberTypes { get => throw null; }
                public System.Xml.Schema.XmlSchemaObjectCollection BaseTypes { get => throw null; }
                public System.Xml.XmlQualifiedName[] MemberTypes { get => throw null; set => throw null; }
                public XmlSchemaSimpleTypeUnion() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaTotalDigitsFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaTotalDigitsFacet : System.Xml.Schema.XmlSchemaNumericFacet
            {
                public XmlSchemaTotalDigitsFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaType : System.Xml.Schema.XmlSchemaAnnotated
            {
                public object BaseSchemaType { get => throw null; }
                public System.Xml.Schema.XmlSchemaType BaseXmlSchemaType { get => throw null; }
                public System.Xml.Schema.XmlSchemaDatatype Datatype { get => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod DerivedBy { get => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod Final { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaDerivationMethod FinalResolved { get => throw null; }
                public static System.Xml.Schema.XmlSchemaComplexType GetBuiltInComplexType(System.Xml.XmlQualifiedName qualifiedName) => throw null;
                public static System.Xml.Schema.XmlSchemaComplexType GetBuiltInComplexType(System.Xml.Schema.XmlTypeCode typeCode) => throw null;
                public static System.Xml.Schema.XmlSchemaSimpleType GetBuiltInSimpleType(System.Xml.XmlQualifiedName qualifiedName) => throw null;
                public static System.Xml.Schema.XmlSchemaSimpleType GetBuiltInSimpleType(System.Xml.Schema.XmlTypeCode typeCode) => throw null;
                public static bool IsDerivedFrom(System.Xml.Schema.XmlSchemaType derivedType, System.Xml.Schema.XmlSchemaType baseType, System.Xml.Schema.XmlSchemaDerivationMethod except) => throw null;
                public virtual bool IsMixed { get => throw null; set => throw null; }
                public string Name { get => throw null; set => throw null; }
                public System.Xml.XmlQualifiedName QualifiedName { get => throw null; }
                public System.Xml.Schema.XmlTypeCode TypeCode { get => throw null; }
                public XmlSchemaType() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaUnique` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaUnique : System.Xml.Schema.XmlSchemaIdentityConstraint
            {
                public XmlSchemaUnique() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaUse` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlSchemaUse
            {
                None,
                Optional,
                Prohibited,
                Required,
            }

            // Generated from `System.Xml.Schema.XmlSchemaValidationException` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaValidationException : System.Xml.Schema.XmlSchemaException
            {
                public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
                protected internal void SetSourceObject(object sourceObject) => throw null;
                public object SourceObject { get => throw null; }
                public XmlSchemaValidationException(string message, System.Exception innerException, int lineNumber, int linePosition) => throw null;
                public XmlSchemaValidationException(string message, System.Exception innerException) => throw null;
                public XmlSchemaValidationException(string message) => throw null;
                public XmlSchemaValidationException() => throw null;
                protected XmlSchemaValidationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaValidationFlags` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            [System.Flags]
            public enum XmlSchemaValidationFlags
            {
                AllowXmlAttributes,
                None,
                ProcessIdentityConstraints,
                ProcessInlineSchema,
                ProcessSchemaLocation,
                ReportValidationWarnings,
            }

            // Generated from `System.Xml.Schema.XmlSchemaValidator` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaValidator
            {
                public void AddSchema(System.Xml.Schema.XmlSchema schema) => throw null;
                public void EndValidation() => throw null;
                public System.Xml.Schema.XmlSchemaAttribute[] GetExpectedAttributes() => throw null;
                public System.Xml.Schema.XmlSchemaParticle[] GetExpectedParticles() => throw null;
                public void GetUnspecifiedDefaultAttributes(System.Collections.ArrayList defaultAttributes) => throw null;
                public void Initialize(System.Xml.Schema.XmlSchemaObject partialValidationType) => throw null;
                public void Initialize() => throw null;
                public System.Xml.IXmlLineInfo LineInfoProvider { get => throw null; set => throw null; }
                public void SkipToEndElement(System.Xml.Schema.XmlSchemaInfo schemaInfo) => throw null;
                public System.Uri SourceUri { get => throw null; set => throw null; }
                public object ValidateAttribute(string localName, string namespaceUri, string attributeValue, System.Xml.Schema.XmlSchemaInfo schemaInfo) => throw null;
                public object ValidateAttribute(string localName, string namespaceUri, System.Xml.Schema.XmlValueGetter attributeValue, System.Xml.Schema.XmlSchemaInfo schemaInfo) => throw null;
                public void ValidateElement(string localName, string namespaceUri, System.Xml.Schema.XmlSchemaInfo schemaInfo, string xsiType, string xsiNil, string xsiSchemaLocation, string xsiNoNamespaceSchemaLocation) => throw null;
                public void ValidateElement(string localName, string namespaceUri, System.Xml.Schema.XmlSchemaInfo schemaInfo) => throw null;
                public object ValidateEndElement(System.Xml.Schema.XmlSchemaInfo schemaInfo, object typedValue) => throw null;
                public object ValidateEndElement(System.Xml.Schema.XmlSchemaInfo schemaInfo) => throw null;
                public void ValidateEndOfAttributes(System.Xml.Schema.XmlSchemaInfo schemaInfo) => throw null;
                public void ValidateText(string elementValue) => throw null;
                public void ValidateText(System.Xml.Schema.XmlValueGetter elementValue) => throw null;
                public void ValidateWhitespace(string elementValue) => throw null;
                public void ValidateWhitespace(System.Xml.Schema.XmlValueGetter elementValue) => throw null;
                public event System.Xml.Schema.ValidationEventHandler ValidationEventHandler;
                public object ValidationEventSender { get => throw null; set => throw null; }
                public System.Xml.XmlResolver XmlResolver { set => throw null; }
                public XmlSchemaValidator(System.Xml.XmlNameTable nameTable, System.Xml.Schema.XmlSchemaSet schemas, System.Xml.IXmlNamespaceResolver namespaceResolver, System.Xml.Schema.XmlSchemaValidationFlags validationFlags) => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaValidity` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlSchemaValidity
            {
                Invalid,
                NotKnown,
                Valid,
            }

            // Generated from `System.Xml.Schema.XmlSchemaWhiteSpaceFacet` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaWhiteSpaceFacet : System.Xml.Schema.XmlSchemaFacet
            {
                public XmlSchemaWhiteSpaceFacet() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSchemaXPath` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaXPath : System.Xml.Schema.XmlSchemaAnnotated
            {
                public string XPath { get => throw null; set => throw null; }
                public XmlSchemaXPath() => throw null;
            }

            // Generated from `System.Xml.Schema.XmlSeverityType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlSeverityType
            {
                Error,
                Warning,
            }

            // Generated from `System.Xml.Schema.XmlTypeCode` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlTypeCode
            {
                AnyAtomicType,
                AnyUri,
                Attribute,
                Base64Binary,
                Boolean,
                Byte,
                Comment,
                Date,
                DateTime,
                DayTimeDuration,
                Decimal,
                Document,
                Double,
                Duration,
                Element,
                Entity,
                Float,
                GDay,
                GMonth,
                GMonthDay,
                GYear,
                GYearMonth,
                HexBinary,
                Id,
                Idref,
                Int,
                Integer,
                Item,
                Language,
                Long,
                NCName,
                Name,
                Namespace,
                NegativeInteger,
                NmToken,
                Node,
                NonNegativeInteger,
                NonPositiveInteger,
                None,
                NormalizedString,
                Notation,
                PositiveInteger,
                ProcessingInstruction,
                QName,
                Short,
                String,
                Text,
                Time,
                Token,
                UnsignedByte,
                UnsignedInt,
                UnsignedLong,
                UnsignedShort,
                UntypedAtomic,
                YearMonthDuration,
            }

            // Generated from `System.Xml.Schema.XmlValueGetter` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public delegate object XmlValueGetter();

        }
        namespace Serialization
        {
            // Generated from `System.Xml.Serialization.IXmlSerializable` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public interface IXmlSerializable
            {
                System.Xml.Schema.XmlSchema GetSchema();
                void ReadXml(System.Xml.XmlReader reader);
                void WriteXml(System.Xml.XmlWriter writer);
            }

            // Generated from `System.Xml.Serialization.XmlAnyAttributeAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlAnyAttributeAttribute : System.Attribute
            {
                public XmlAnyAttributeAttribute() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlAnyElementAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlAnyElementAttribute : System.Attribute
            {
                public string Name { get => throw null; set => throw null; }
                public string Namespace { get => throw null; set => throw null; }
                public int Order { get => throw null; set => throw null; }
                public XmlAnyElementAttribute(string name, string ns) => throw null;
                public XmlAnyElementAttribute(string name) => throw null;
                public XmlAnyElementAttribute() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlAttributeAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlAttributeAttribute : System.Attribute
            {
                public string AttributeName { get => throw null; set => throw null; }
                public string DataType { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaForm Form { get => throw null; set => throw null; }
                public string Namespace { get => throw null; set => throw null; }
                public System.Type Type { get => throw null; set => throw null; }
                public XmlAttributeAttribute(string attributeName, System.Type type) => throw null;
                public XmlAttributeAttribute(string attributeName) => throw null;
                public XmlAttributeAttribute(System.Type type) => throw null;
                public XmlAttributeAttribute() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlElementAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlElementAttribute : System.Attribute
            {
                public string DataType { get => throw null; set => throw null; }
                public string ElementName { get => throw null; set => throw null; }
                public System.Xml.Schema.XmlSchemaForm Form { get => throw null; set => throw null; }
                public bool IsNullable { get => throw null; set => throw null; }
                public string Namespace { get => throw null; set => throw null; }
                public int Order { get => throw null; set => throw null; }
                public System.Type Type { get => throw null; set => throw null; }
                public XmlElementAttribute(string elementName, System.Type type) => throw null;
                public XmlElementAttribute(string elementName) => throw null;
                public XmlElementAttribute(System.Type type) => throw null;
                public XmlElementAttribute() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlEnumAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlEnumAttribute : System.Attribute
            {
                public string Name { get => throw null; set => throw null; }
                public XmlEnumAttribute(string name) => throw null;
                public XmlEnumAttribute() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlIgnoreAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlIgnoreAttribute : System.Attribute
            {
                public XmlIgnoreAttribute() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlNamespaceDeclarationsAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlNamespaceDeclarationsAttribute : System.Attribute
            {
                public XmlNamespaceDeclarationsAttribute() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlRootAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlRootAttribute : System.Attribute
            {
                public string DataType { get => throw null; set => throw null; }
                public string ElementName { get => throw null; set => throw null; }
                public bool IsNullable { get => throw null; set => throw null; }
                public string Namespace { get => throw null; set => throw null; }
                public XmlRootAttribute(string elementName) => throw null;
                public XmlRootAttribute() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlSchemaProviderAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSchemaProviderAttribute : System.Attribute
            {
                public bool IsAny { get => throw null; set => throw null; }
                public string MethodName { get => throw null; }
                public XmlSchemaProviderAttribute(string methodName) => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlSerializerNamespaces` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlSerializerNamespaces
            {
                public void Add(string prefix, string ns) => throw null;
                public int Count { get => throw null; }
                public System.Xml.XmlQualifiedName[] ToArray() => throw null;
                public XmlSerializerNamespaces(System.Xml.XmlQualifiedName[] namespaces) => throw null;
                public XmlSerializerNamespaces(System.Xml.Serialization.XmlSerializerNamespaces namespaces) => throw null;
                public XmlSerializerNamespaces() => throw null;
            }

            // Generated from `System.Xml.Serialization.XmlTextAttribute` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XmlTextAttribute : System.Attribute
            {
                public string DataType { get => throw null; set => throw null; }
                public System.Type Type { get => throw null; set => throw null; }
                public XmlTextAttribute(System.Type type) => throw null;
                public XmlTextAttribute() => throw null;
            }

        }
        namespace XPath
        {
            // Generated from `System.Xml.XPath.IXPathNavigable` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public interface IXPathNavigable
            {
                System.Xml.XPath.XPathNavigator CreateNavigator();
            }

            // Generated from `System.Xml.XPath.XPathExpression` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XPathExpression
            {
                public abstract void AddSort(object expr, System.Xml.XPath.XmlSortOrder order, System.Xml.XPath.XmlCaseOrder caseOrder, string lang, System.Xml.XPath.XmlDataType dataType);
                public abstract void AddSort(object expr, System.Collections.IComparer comparer);
                public abstract System.Xml.XPath.XPathExpression Clone();
                public static System.Xml.XPath.XPathExpression Compile(string xpath, System.Xml.IXmlNamespaceResolver nsResolver) => throw null;
                public static System.Xml.XPath.XPathExpression Compile(string xpath) => throw null;
                public abstract string Expression { get; }
                public abstract System.Xml.XPath.XPathResultType ReturnType { get; }
                public abstract void SetContext(System.Xml.XmlNamespaceManager nsManager);
                public abstract void SetContext(System.Xml.IXmlNamespaceResolver nsResolver);
            }

            // Generated from `System.Xml.XPath.XPathItem` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XPathItem
            {
                public abstract bool IsNode { get; }
                public abstract object TypedValue { get; }
                public abstract string Value { get; }
                public virtual object ValueAs(System.Type returnType) => throw null;
                public abstract object ValueAs(System.Type returnType, System.Xml.IXmlNamespaceResolver nsResolver);
                public abstract bool ValueAsBoolean { get; }
                public abstract System.DateTime ValueAsDateTime { get; }
                public abstract double ValueAsDouble { get; }
                public abstract int ValueAsInt { get; }
                public abstract System.Int64 ValueAsLong { get; }
                public abstract System.Type ValueType { get; }
                protected XPathItem() => throw null;
                public abstract System.Xml.Schema.XmlSchemaType XmlType { get; }
            }

            // Generated from `System.Xml.XPath.XPathNamespaceScope` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XPathNamespaceScope
            {
                All,
                ExcludeXml,
                Local,
            }

            // Generated from `System.Xml.XPath.XPathNavigator` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XPathNavigator : System.Xml.XPath.XPathItem, System.Xml.XPath.IXPathNavigable, System.Xml.IXmlNamespaceResolver, System.ICloneable
            {
                public virtual void AppendChild(string newChild) => throw null;
                public virtual void AppendChild(System.Xml.XmlReader newChild) => throw null;
                public virtual void AppendChild(System.Xml.XPath.XPathNavigator newChild) => throw null;
                public virtual System.Xml.XmlWriter AppendChild() => throw null;
                public virtual void AppendChildElement(string prefix, string localName, string namespaceURI, string value) => throw null;
                public abstract string BaseURI { get; }
                public virtual bool CanEdit { get => throw null; }
                public virtual bool CheckValidity(System.Xml.Schema.XmlSchemaSet schemas, System.Xml.Schema.ValidationEventHandler validationEventHandler) => throw null;
                public abstract System.Xml.XPath.XPathNavigator Clone();
                object System.ICloneable.Clone() => throw null;
                public virtual System.Xml.XmlNodeOrder ComparePosition(System.Xml.XPath.XPathNavigator nav) => throw null;
                public virtual System.Xml.XPath.XPathExpression Compile(string xpath) => throw null;
                public virtual void CreateAttribute(string prefix, string localName, string namespaceURI, string value) => throw null;
                public virtual System.Xml.XmlWriter CreateAttributes() => throw null;
                public virtual System.Xml.XPath.XPathNavigator CreateNavigator() => throw null;
                public virtual void DeleteRange(System.Xml.XPath.XPathNavigator lastSiblingToDelete) => throw null;
                public virtual void DeleteSelf() => throw null;
                public virtual object Evaluate(string xpath, System.Xml.IXmlNamespaceResolver resolver) => throw null;
                public virtual object Evaluate(string xpath) => throw null;
                public virtual object Evaluate(System.Xml.XPath.XPathExpression expr, System.Xml.XPath.XPathNodeIterator context) => throw null;
                public virtual object Evaluate(System.Xml.XPath.XPathExpression expr) => throw null;
                public virtual string GetAttribute(string localName, string namespaceURI) => throw null;
                public virtual string GetNamespace(string name) => throw null;
                public virtual System.Collections.Generic.IDictionary<string, string> GetNamespacesInScope(System.Xml.XmlNamespaceScope scope) => throw null;
                public virtual bool HasAttributes { get => throw null; }
                public virtual bool HasChildren { get => throw null; }
                public virtual string InnerXml { get => throw null; set => throw null; }
                public virtual void InsertAfter(string newSibling) => throw null;
                public virtual void InsertAfter(System.Xml.XmlReader newSibling) => throw null;
                public virtual void InsertAfter(System.Xml.XPath.XPathNavigator newSibling) => throw null;
                public virtual System.Xml.XmlWriter InsertAfter() => throw null;
                public virtual void InsertBefore(string newSibling) => throw null;
                public virtual void InsertBefore(System.Xml.XmlReader newSibling) => throw null;
                public virtual void InsertBefore(System.Xml.XPath.XPathNavigator newSibling) => throw null;
                public virtual System.Xml.XmlWriter InsertBefore() => throw null;
                public virtual void InsertElementAfter(string prefix, string localName, string namespaceURI, string value) => throw null;
                public virtual void InsertElementBefore(string prefix, string localName, string namespaceURI, string value) => throw null;
                public virtual bool IsDescendant(System.Xml.XPath.XPathNavigator nav) => throw null;
                public abstract bool IsEmptyElement { get; }
                public override bool IsNode { get => throw null; }
                public abstract bool IsSamePosition(System.Xml.XPath.XPathNavigator other);
                public abstract string LocalName { get; }
                public virtual string LookupNamespace(string prefix) => throw null;
                public virtual string LookupPrefix(string namespaceURI) => throw null;
                public virtual bool Matches(string xpath) => throw null;
                public virtual bool Matches(System.Xml.XPath.XPathExpression expr) => throw null;
                public abstract bool MoveTo(System.Xml.XPath.XPathNavigator other);
                public virtual bool MoveToAttribute(string localName, string namespaceURI) => throw null;
                public virtual bool MoveToChild(string localName, string namespaceURI) => throw null;
                public virtual bool MoveToChild(System.Xml.XPath.XPathNodeType type) => throw null;
                public virtual bool MoveToFirst() => throw null;
                public abstract bool MoveToFirstAttribute();
                public abstract bool MoveToFirstChild();
                public bool MoveToFirstNamespace() => throw null;
                public abstract bool MoveToFirstNamespace(System.Xml.XPath.XPathNamespaceScope namespaceScope);
                public virtual bool MoveToFollowing(string localName, string namespaceURI, System.Xml.XPath.XPathNavigator end) => throw null;
                public virtual bool MoveToFollowing(string localName, string namespaceURI) => throw null;
                public virtual bool MoveToFollowing(System.Xml.XPath.XPathNodeType type, System.Xml.XPath.XPathNavigator end) => throw null;
                public virtual bool MoveToFollowing(System.Xml.XPath.XPathNodeType type) => throw null;
                public abstract bool MoveToId(string id);
                public virtual bool MoveToNamespace(string name) => throw null;
                public virtual bool MoveToNext(string localName, string namespaceURI) => throw null;
                public virtual bool MoveToNext(System.Xml.XPath.XPathNodeType type) => throw null;
                public abstract bool MoveToNext();
                public abstract bool MoveToNextAttribute();
                public bool MoveToNextNamespace() => throw null;
                public abstract bool MoveToNextNamespace(System.Xml.XPath.XPathNamespaceScope namespaceScope);
                public abstract bool MoveToParent();
                public abstract bool MoveToPrevious();
                public virtual void MoveToRoot() => throw null;
                public abstract string Name { get; }
                public abstract System.Xml.XmlNameTable NameTable { get; }
                public abstract string NamespaceURI { get; }
                public static System.Collections.IEqualityComparer NavigatorComparer { get => throw null; }
                public abstract System.Xml.XPath.XPathNodeType NodeType { get; }
                public virtual string OuterXml { get => throw null; set => throw null; }
                public abstract string Prefix { get; }
                public virtual void PrependChild(string newChild) => throw null;
                public virtual void PrependChild(System.Xml.XmlReader newChild) => throw null;
                public virtual void PrependChild(System.Xml.XPath.XPathNavigator newChild) => throw null;
                public virtual System.Xml.XmlWriter PrependChild() => throw null;
                public virtual void PrependChildElement(string prefix, string localName, string namespaceURI, string value) => throw null;
                public virtual System.Xml.XmlReader ReadSubtree() => throw null;
                public virtual System.Xml.XmlWriter ReplaceRange(System.Xml.XPath.XPathNavigator lastSiblingToReplace) => throw null;
                public virtual void ReplaceSelf(string newNode) => throw null;
                public virtual void ReplaceSelf(System.Xml.XmlReader newNode) => throw null;
                public virtual void ReplaceSelf(System.Xml.XPath.XPathNavigator newNode) => throw null;
                public virtual System.Xml.Schema.IXmlSchemaInfo SchemaInfo { get => throw null; }
                public virtual System.Xml.XPath.XPathNodeIterator Select(string xpath, System.Xml.IXmlNamespaceResolver resolver) => throw null;
                public virtual System.Xml.XPath.XPathNodeIterator Select(string xpath) => throw null;
                public virtual System.Xml.XPath.XPathNodeIterator Select(System.Xml.XPath.XPathExpression expr) => throw null;
                public virtual System.Xml.XPath.XPathNodeIterator SelectAncestors(string name, string namespaceURI, bool matchSelf) => throw null;
                public virtual System.Xml.XPath.XPathNodeIterator SelectAncestors(System.Xml.XPath.XPathNodeType type, bool matchSelf) => throw null;
                public virtual System.Xml.XPath.XPathNodeIterator SelectChildren(string name, string namespaceURI) => throw null;
                public virtual System.Xml.XPath.XPathNodeIterator SelectChildren(System.Xml.XPath.XPathNodeType type) => throw null;
                public virtual System.Xml.XPath.XPathNodeIterator SelectDescendants(string name, string namespaceURI, bool matchSelf) => throw null;
                public virtual System.Xml.XPath.XPathNodeIterator SelectDescendants(System.Xml.XPath.XPathNodeType type, bool matchSelf) => throw null;
                public virtual System.Xml.XPath.XPathNavigator SelectSingleNode(string xpath, System.Xml.IXmlNamespaceResolver resolver) => throw null;
                public virtual System.Xml.XPath.XPathNavigator SelectSingleNode(string xpath) => throw null;
                public virtual System.Xml.XPath.XPathNavigator SelectSingleNode(System.Xml.XPath.XPathExpression expression) => throw null;
                public virtual void SetTypedValue(object typedValue) => throw null;
                public virtual void SetValue(string value) => throw null;
                public override string ToString() => throw null;
                public override object TypedValue { get => throw null; }
                public virtual object UnderlyingObject { get => throw null; }
                public override object ValueAs(System.Type returnType, System.Xml.IXmlNamespaceResolver nsResolver) => throw null;
                public override bool ValueAsBoolean { get => throw null; }
                public override System.DateTime ValueAsDateTime { get => throw null; }
                public override double ValueAsDouble { get => throw null; }
                public override int ValueAsInt { get => throw null; }
                public override System.Int64 ValueAsLong { get => throw null; }
                public override System.Type ValueType { get => throw null; }
                public virtual void WriteSubtree(System.Xml.XmlWriter writer) => throw null;
                protected XPathNavigator() => throw null;
                public virtual string XmlLang { get => throw null; }
                public override System.Xml.Schema.XmlSchemaType XmlType { get => throw null; }
            }

            // Generated from `System.Xml.XPath.XPathNodeIterator` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XPathNodeIterator : System.ICloneable, System.Collections.IEnumerable
            {
                public abstract System.Xml.XPath.XPathNodeIterator Clone();
                object System.ICloneable.Clone() => throw null;
                public virtual int Count { get => throw null; }
                public abstract System.Xml.XPath.XPathNavigator Current { get; }
                public abstract int CurrentPosition { get; }
                public virtual System.Collections.IEnumerator GetEnumerator() => throw null;
                public abstract bool MoveNext();
                protected XPathNodeIterator() => throw null;
            }

            // Generated from `System.Xml.XPath.XPathNodeType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XPathNodeType
            {
                All,
                Attribute,
                Comment,
                Element,
                Namespace,
                ProcessingInstruction,
                Root,
                SignificantWhitespace,
                Text,
                Whitespace,
            }

            // Generated from `System.Xml.XPath.XPathResultType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XPathResultType
            {
                Any,
                Boolean,
                Error,
                Navigator,
                NodeSet,
                Number,
                String,
            }

            // Generated from `System.Xml.XPath.XmlCaseOrder` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlCaseOrder
            {
                LowerFirst,
                None,
                UpperFirst,
            }

            // Generated from `System.Xml.XPath.XmlDataType` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlDataType
            {
                Number,
                Text,
            }

            // Generated from `System.Xml.XPath.XmlSortOrder` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public enum XmlSortOrder
            {
                Ascending,
                Descending,
            }

        }
        namespace Xsl
        {
            // Generated from `System.Xml.Xsl.IXsltContextFunction` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public interface IXsltContextFunction
            {
                System.Xml.XPath.XPathResultType[] ArgTypes { get; }
                object Invoke(System.Xml.Xsl.XsltContext xsltContext, object[] args, System.Xml.XPath.XPathNavigator docContext);
                int Maxargs { get; }
                int Minargs { get; }
                System.Xml.XPath.XPathResultType ReturnType { get; }
            }

            // Generated from `System.Xml.Xsl.IXsltContextVariable` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public interface IXsltContextVariable
            {
                object Evaluate(System.Xml.Xsl.XsltContext xsltContext);
                bool IsLocal { get; }
                bool IsParam { get; }
                System.Xml.XPath.XPathResultType VariableType { get; }
            }

            // Generated from `System.Xml.Xsl.XslCompiledTransform` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XslCompiledTransform
            {
                public void Load(string stylesheetUri, System.Xml.Xsl.XsltSettings settings, System.Xml.XmlResolver stylesheetResolver) => throw null;
                public void Load(string stylesheetUri) => throw null;
                public void Load(System.Xml.XmlReader stylesheet, System.Xml.Xsl.XsltSettings settings, System.Xml.XmlResolver stylesheetResolver) => throw null;
                public void Load(System.Xml.XmlReader stylesheet) => throw null;
                public void Load(System.Xml.XPath.IXPathNavigable stylesheet, System.Xml.Xsl.XsltSettings settings, System.Xml.XmlResolver stylesheetResolver) => throw null;
                public void Load(System.Xml.XPath.IXPathNavigable stylesheet) => throw null;
                public void Load(System.Type compiledStylesheet) => throw null;
                public void Load(System.Reflection.MethodInfo executeMethod, System.Byte[] queryData, System.Type[] earlyBoundTypes) => throw null;
                public System.Xml.XmlWriterSettings OutputSettings { get => throw null; }
                public void Transform(string inputUri, string resultsFile) => throw null;
                public void Transform(string inputUri, System.Xml.Xsl.XsltArgumentList arguments, System.Xml.XmlWriter results) => throw null;
                public void Transform(string inputUri, System.Xml.Xsl.XsltArgumentList arguments, System.IO.TextWriter results) => throw null;
                public void Transform(string inputUri, System.Xml.Xsl.XsltArgumentList arguments, System.IO.Stream results) => throw null;
                public void Transform(string inputUri, System.Xml.XmlWriter results) => throw null;
                public void Transform(System.Xml.XmlReader input, System.Xml.Xsl.XsltArgumentList arguments, System.Xml.XmlWriter results, System.Xml.XmlResolver documentResolver) => throw null;
                public void Transform(System.Xml.XmlReader input, System.Xml.Xsl.XsltArgumentList arguments, System.Xml.XmlWriter results) => throw null;
                public void Transform(System.Xml.XmlReader input, System.Xml.Xsl.XsltArgumentList arguments, System.IO.TextWriter results) => throw null;
                public void Transform(System.Xml.XmlReader input, System.Xml.Xsl.XsltArgumentList arguments, System.IO.Stream results) => throw null;
                public void Transform(System.Xml.XmlReader input, System.Xml.XmlWriter results) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList arguments, System.Xml.XmlWriter results, System.Xml.XmlResolver documentResolver) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList arguments, System.Xml.XmlWriter results) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList arguments, System.IO.TextWriter results) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList arguments, System.IO.Stream results) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.XmlWriter results) => throw null;
                public XslCompiledTransform(bool enableDebug) => throw null;
                public XslCompiledTransform() => throw null;
            }

            // Generated from `System.Xml.Xsl.XslTransform` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XslTransform
            {
                public void Load(string url, System.Xml.XmlResolver resolver) => throw null;
                public void Load(string url) => throw null;
                public void Load(System.Xml.XmlReader stylesheet, System.Xml.XmlResolver resolver) => throw null;
                public void Load(System.Xml.XmlReader stylesheet) => throw null;
                public void Load(System.Xml.XPath.XPathNavigator stylesheet, System.Xml.XmlResolver resolver) => throw null;
                public void Load(System.Xml.XPath.XPathNavigator stylesheet) => throw null;
                public void Load(System.Xml.XPath.IXPathNavigable stylesheet, System.Xml.XmlResolver resolver) => throw null;
                public void Load(System.Xml.XPath.IXPathNavigable stylesheet) => throw null;
                public void Transform(string inputfile, string outputfile, System.Xml.XmlResolver resolver) => throw null;
                public void Transform(string inputfile, string outputfile) => throw null;
                public void Transform(System.Xml.XPath.XPathNavigator input, System.Xml.Xsl.XsltArgumentList args, System.Xml.XmlWriter output, System.Xml.XmlResolver resolver) => throw null;
                public void Transform(System.Xml.XPath.XPathNavigator input, System.Xml.Xsl.XsltArgumentList args, System.Xml.XmlWriter output) => throw null;
                public void Transform(System.Xml.XPath.XPathNavigator input, System.Xml.Xsl.XsltArgumentList args, System.IO.TextWriter output, System.Xml.XmlResolver resolver) => throw null;
                public void Transform(System.Xml.XPath.XPathNavigator input, System.Xml.Xsl.XsltArgumentList args, System.IO.TextWriter output) => throw null;
                public void Transform(System.Xml.XPath.XPathNavigator input, System.Xml.Xsl.XsltArgumentList args, System.IO.Stream output, System.Xml.XmlResolver resolver) => throw null;
                public void Transform(System.Xml.XPath.XPathNavigator input, System.Xml.Xsl.XsltArgumentList args, System.IO.Stream output) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList args, System.Xml.XmlWriter output, System.Xml.XmlResolver resolver) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList args, System.Xml.XmlWriter output) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList args, System.IO.TextWriter output, System.Xml.XmlResolver resolver) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList args, System.IO.TextWriter output) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList args, System.IO.Stream output, System.Xml.XmlResolver resolver) => throw null;
                public void Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList args, System.IO.Stream output) => throw null;
                public System.Xml.XmlReader Transform(System.Xml.XPath.XPathNavigator input, System.Xml.Xsl.XsltArgumentList args, System.Xml.XmlResolver resolver) => throw null;
                public System.Xml.XmlReader Transform(System.Xml.XPath.XPathNavigator input, System.Xml.Xsl.XsltArgumentList args) => throw null;
                public System.Xml.XmlReader Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList args, System.Xml.XmlResolver resolver) => throw null;
                public System.Xml.XmlReader Transform(System.Xml.XPath.IXPathNavigable input, System.Xml.Xsl.XsltArgumentList args) => throw null;
                public System.Xml.XmlResolver XmlResolver { set => throw null; }
                public XslTransform() => throw null;
            }

            // Generated from `System.Xml.Xsl.XsltArgumentList` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XsltArgumentList
            {
                public void AddExtensionObject(string namespaceUri, object extension) => throw null;
                public void AddParam(string name, string namespaceUri, object parameter) => throw null;
                public void Clear() => throw null;
                public object GetExtensionObject(string namespaceUri) => throw null;
                public object GetParam(string name, string namespaceUri) => throw null;
                public object RemoveExtensionObject(string namespaceUri) => throw null;
                public object RemoveParam(string name, string namespaceUri) => throw null;
                public XsltArgumentList() => throw null;
                public event System.Xml.Xsl.XsltMessageEncounteredEventHandler XsltMessageEncountered;
            }

            // Generated from `System.Xml.Xsl.XsltCompileException` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XsltCompileException : System.Xml.Xsl.XsltException
            {
                public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
                public XsltCompileException(string message, System.Exception innerException) => throw null;
                public XsltCompileException(string message) => throw null;
                public XsltCompileException(System.Exception inner, string sourceUri, int lineNumber, int linePosition) => throw null;
                public XsltCompileException() => throw null;
                protected XsltCompileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
            }

            // Generated from `System.Xml.Xsl.XsltContext` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XsltContext : System.Xml.XmlNamespaceManager
            {
                public abstract int CompareDocument(string baseUri, string nextbaseUri);
                public abstract bool PreserveWhitespace(System.Xml.XPath.XPathNavigator node);
                public abstract System.Xml.Xsl.IXsltContextFunction ResolveFunction(string prefix, string name, System.Xml.XPath.XPathResultType[] ArgTypes);
                public abstract System.Xml.Xsl.IXsltContextVariable ResolveVariable(string prefix, string name);
                public abstract bool Whitespace { get; }
                protected XsltContext(System.Xml.NameTable table) : base(default(System.Xml.XmlNameTable)) => throw null;
                protected XsltContext() : base(default(System.Xml.XmlNameTable)) => throw null;
            }

            // Generated from `System.Xml.Xsl.XsltException` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XsltException : System.SystemException
            {
                public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
                public virtual int LineNumber { get => throw null; }
                public virtual int LinePosition { get => throw null; }
                public override string Message { get => throw null; }
                public virtual string SourceUri { get => throw null; }
                public XsltException(string message, System.Exception innerException) => throw null;
                public XsltException(string message) => throw null;
                public XsltException() => throw null;
                protected XsltException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => throw null;
            }

            // Generated from `System.Xml.Xsl.XsltMessageEncounteredEventArgs` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public abstract class XsltMessageEncounteredEventArgs : System.EventArgs
            {
                public abstract string Message { get; }
                protected XsltMessageEncounteredEventArgs() => throw null;
            }

            // Generated from `System.Xml.Xsl.XsltMessageEncounteredEventHandler` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public delegate void XsltMessageEncounteredEventHandler(object sender, System.Xml.Xsl.XsltMessageEncounteredEventArgs e);

            // Generated from `System.Xml.Xsl.XsltSettings` in `System.Xml.ReaderWriter, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`
            public class XsltSettings
            {
                public static System.Xml.Xsl.XsltSettings Default { get => throw null; }
                public bool EnableDocumentFunction { get => throw null; set => throw null; }
                public bool EnableScript { get => throw null; set => throw null; }
                public static System.Xml.Xsl.XsltSettings TrustedXslt { get => throw null; }
                public XsltSettings(bool enableDocumentFunction, bool enableScript) => throw null;
                public XsltSettings() => throw null;
            }

        }
    }
}
