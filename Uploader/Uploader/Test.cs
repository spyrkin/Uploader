using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Uploader
{
    class Test
    {

        public Player p;

        public void exec()
        {
            p = new Player("ivan");
            change(p);
            Console.WriteLine(p.Name);
        }


        public void change(Player player)
        {
            player = new Player("Artem");
        }

        public class Player
        {

            public string Name;

            public Player(string name)
            {
                Name = name;
            }
        }
    }
}
