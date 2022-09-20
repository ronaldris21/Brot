namespace Brot.Trigger
{
    using Xamarin.Forms;
    public class FadeTriggerAction : TriggerAction<VisualElement>
    {
        public double deltaLuminosity { get; set; }
        public Color ColorEfecto { get; set; }
        protected override void Invoke(VisualElement sender)
        {
            sender.Animate("FadeActionTrigger", new Animation((d) =>
             {
                 
                 //sender.BackgroundColor = Color./*/*;*/*/
                 //sender.BackgroundColor = colorEfecto.AddLuminosity(deltaLuminosity);
             }),
             length: 1000, //Miliseconds
             easing: Easing.BounceIn
             );
        }
    }
}
