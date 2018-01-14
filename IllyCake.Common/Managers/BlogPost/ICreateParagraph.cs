namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;

    public interface ICreateParagraph
    {
        string BlogId { get; set; }

        string Text { get; set; }
        
        string CssClassList { get; set; }

        int? ThumbImageId { get; set; }
        
        string EmbedVideoHtml { get; set; }
        
        ParagraphType Type { get; set; }
        
        SpecialContentPosition SpecialContentPosition { get; set; }
    }
}
