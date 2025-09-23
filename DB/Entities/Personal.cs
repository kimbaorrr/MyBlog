using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MyBlog.DB.Entities
{
    public class Personal
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.Empty;

        [BsonElement("full_name")]
        public LocalizedString FullName { get; set; } = new LocalizedString();

        [BsonElement("dob")]
        public string Dob { get; set; } = string.Empty;

        [BsonElement("gender")]
        public LocalizedString Gender { get; set; } = new LocalizedString();

        [BsonElement("nationality")]
        public LocalizedString Nationality { get; set; } = new LocalizedString();

        [BsonElement("job")]
        public LocalizedString Job { get; set; } = new LocalizedString();

        [BsonElement("workplace")]
        public LocalizedString Workplace { get; set; } = new LocalizedString();

        [BsonElement("address")]
        public LocalizedString Address { get; set; } = new LocalizedString();

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("avatar")]
        public string Avatar { get; set; } = string.Empty;

        [BsonElement("favorite")]
        public LocalizedString Favorite { get; set; } = new LocalizedString();

        [BsonElement("skills")]
        public Skills Skills { get; set; } = new Skills();

        [BsonElement("languages")]
        public LocalizedLanguages Languages { get; set; } = new LocalizedLanguages();

        [BsonElement("educations")]
        public IList<Education> Educations { get; set; } = new List<Education>();

        [BsonElement("experiences")]
        public IList<Experience> Experiences { get; set; } = new List<Experience>();

        [BsonElement("certifications")]
        public IList<Certification> Certifications { get; set; } = new List<Certification>();

        [BsonElement("socials")]
        public Socials Socials { get; set; } = new Socials();
    }

    public class LocalizedLanguages
    {
        [BsonElement("en")]
        public IList<string> En { get; set; } = new List<string>();

        [BsonElement("vi")]
        public IList<string> Vi { get; set; } = new List<string>();
    }

    public class Skills
    {
        [BsonElement("short_skills")]
        public LocalizedSkillList ShortSkills { get; set; } = new LocalizedSkillList();

        [BsonElement("hard_skills")]
        public LocalizedSkillList HardSkills { get; set; } = new LocalizedSkillList();
    }

    public class LocalizedSkillList
    {
        [BsonElement("en")]
        public IList<string> En { get; set; } = new List<string>();

        [BsonElement("vi")]
        public IList<string> Vi { get; set; } = new List<string>();
    }

    public class Education
    {
        [BsonElement("school")]
        public LocalizedString School { get; set; } = new LocalizedString();

        [BsonElement("degree")]
        public LocalizedString Degree { get; set; } = new LocalizedString();

        [BsonElement("start_year")]
        public string StartYear { get; set; } = string.Empty;

        [BsonElement("end_year")]
        public string EndYear { get; set; } = string.Empty;
    }

    public class Experience
    {
        [BsonElement("company_name")]
        public LocalizedString CompanyName { get; set; } = new LocalizedString();

        [BsonElement("role")]
        public LocalizedString Role { get; set; } = new LocalizedString();

        [BsonElement("from_month")]
        public string FromMonth { get; set; } = string.Empty;

        [BsonElement("to_month")]
        public string ToMonth { get; set; } = string.Empty;

        [BsonElement("location")]
        public LocalizedString Location { get; set; } = new LocalizedString();

        [BsonElement("description")]
        public LocalizedString Description { get; set; } = new LocalizedString();
    }

    public class Certification
    {
        [BsonElement("name")]
        public LocalizedString Name { get; set; } = new LocalizedString();

        [BsonElement("date")]
        public string Date { get; set; } = string.Empty;

        [BsonElement("authory")]
        public LocalizedString Authory { get; set; } = new LocalizedString();
    }

    public class Socials
    {
        [BsonElement("git")]
        public SocialAccount? Git { get; set; }

        [BsonElement("twitter")]
        public SocialAccount? Twitter { get; set; }

        [BsonElement("youtube")]
        public SocialAccount? Youtube { get; set; }

        [BsonElement("linkedin")]
        public SocialAccount? Linkedin { get; set; }

        [BsonElement("facebook")]
        public SocialAccount? Facebook { get; set; }
        [BsonElement("x")]
        public SocialAccount? X { get; set; }
    }

    public class SocialAccount
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("url")]
        public string Url { get; set; } = string.Empty;
    }
}
