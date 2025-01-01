using System.Globalization;

namespace Recuitment
{
    class Resume
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return "\n Name: "+Name+" \n Email: "+Email+" \n Position: "+Position+"\n";
        }
    }


}