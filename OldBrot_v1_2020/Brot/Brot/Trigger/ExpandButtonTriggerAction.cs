
namespace Brot.Trigger
{
    #region TriggerAction

    using Xamarin.Forms;
    public class ExpandButtonTriggerAction : TriggerAction<Button>
    {
        protected override void Invoke(Button sender)
        {
            sender.ScaleTo(0.65, length: 50, easing: Easing.CubicOut);
            sender.ScaleTo(1, length: 50, Easing.CubicIn);
        }
    } 
    #endregion
}
