using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace laba3.Models
{
    [DataContractAttribute]
    public class Hateoas
    {

        [DataMemberAttribute]
        public string Href { get; set; }
        [DataMemberAttribute]
        public string Rel { get; set; }
        [DataMemberAttribute]
        public string Method { get; set; }

        public Hateoas(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
    [DataContractAttribute]
    public class HateoasMethods
    {
        [DataMemberAttribute]
        public Hateoas HateOasGet { get; set; }
        [DataMemberAttribute]
        public Hateoas HateOasPut { get; set; }
        [DataMemberAttribute]
        public Hateoas HateOasDelete { get; set; }
        [DataMemberAttribute]
        public Hateoas HateOasPost { get; set; }
        public HateoasMethods(Hateoas hateoasGet, Hateoas hateoasPut, Hateoas hateoasPost, Hateoas hateoasDelete)
        {
            HateOasGet = hateoasGet;
            HateOasPut = hateoasPut;
            HateOasDelete = hateoasDelete;
            HateOasPost = hateoasPost;
        }
    }
    public class HateoasLinks
    {
        [DataMember]
        public string allStudents;
        [DataMember]
        public string self;

        public HateoasLinks(string allStudents, string self)
        {
            this.allStudents = allStudents;
            this.self = self;
        }
    }


    [DataContract]
    public class HateoasPageLinks
    {
        [DataMember]
        public List<string> allPages;
        [DataMember]
        public string self;

        public HateoasPageLinks(List<string> allPages, string self)
        {
            this.allPages = allPages;
            this.self = self;
        }
    }

    public class Link
    {
        public string href;
        public Link(string href) { this.href = href; }
    }

    [DataContract]
    public class Page
    {
        public Page() { }

        [DataMember]
        public List<Student> Students { get; set; }
        [DataMember]
        public HateoasPageLinks _links { get; set; }
    }
}