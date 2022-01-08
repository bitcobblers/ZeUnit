namespace ZeUnit
{
    public class Failed : ZeAssertion
    {
        public Failed(string message)
        {
            this.Status = ZeStatus.Passed;
            this.Message = message;
        }
    }
}