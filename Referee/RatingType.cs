using System.Runtime.Serialization;

namespace Referee
{
    [DataContract]
    public enum RatingType : int
    {
        [EnumMember(Value = "agree")]
        Agree = 1,
        [EnumMember(Value = "disagree")]
        Disagree = 2,
        [EnumMember(Value = "funny")]
        Funny = 3,
        [EnumMember(Value = "friendly")]
        Friendly = 4,
        [EnumMember(Value = "kawaii")]
        Kawaii = 5,
        [EnumMember(Value = "sad")]
        Sad = 6,
        [EnumMember(Value = "artistic")]
        Artistic = 7,
        [EnumMember(Value = "informative")]
        Informative = 8,
        [EnumMember(Value = "idea")]
        Idea = 9,
        [EnumMember(Value = "winner")]
        Winner = 10,
        [EnumMember(Value = "glasses")]
        Glasses = 11,
        [EnumMember(Value = "late")]
        Late = 12,
        [EnumMember(Value = "dumb")]
        Dumb = 13,
        [EnumMember(Value = "citation")]
        CitationNeeded = 14,
        [EnumMember(Value = "optimistic")]
        Optimistic = 15,
        [EnumMember(Value = "zing")]
        Zing = 16,
        [EnumMember(Value = "yeet")]
        Yeet = 17,
    }
}
