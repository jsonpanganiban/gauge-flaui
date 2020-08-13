using System.Text;
using Gauge.CSharp.Lib;

namespace DTAF.Core
{
    public class Logger
    {
        protected static void WriteErrorLine(string message, string details)
        {
            var sb = new StringBuilder();

            sb.Append("ERROR: ");
            sb.Append(message);
            GaugeMessages.WriteMessage(sb.ToString());

            sb.Clear();
            sb.Append("DETAILS: ");
            sb.Append(details);
            GaugeMessages.WriteMessage(sb.ToString());
        }

        protected void Write(string message)
        {
            var sb = new StringBuilder();
            sb.Append(message);
            GaugeMessages.WriteMessage(sb.ToString());
        }

        protected void Write(string source, string message)
        {
            var sb = new StringBuilder();
            sb.Append(source);
            sb.Append(": ");
            sb.Append(message);
            GaugeMessages.WriteMessage(sb.ToString());
        }

        protected void Write(string[] source, string message)
        {
            var sb = new StringBuilder();

            sb.Append(source[0]);
            sb.Append(" ");
            sb.Append(source[1]);
            sb.Append(": ");
            sb.Append(message);
            GaugeMessages.WriteMessage(sb.ToString());
        }
    }
}
