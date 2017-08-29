using System.Runtime.Serialization;



namespace Pictures.WcfService.Models
{
    [DataContract]
    public class Picture
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Image { get; set; }
    }
}