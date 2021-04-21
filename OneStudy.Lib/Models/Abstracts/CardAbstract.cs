namespace OneStudy.Lib.Models.Abstracts
{
    public abstract class CardAbstract
    {
        public string FrontText { get; set; }
        public string BackText { get; set; }

        public virtual Card ToEntity(int cardId)
        {
            var card = new Card(cardId, FrontText, BackText);

            return card;
        }
    }
}
