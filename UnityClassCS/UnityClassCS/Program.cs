using System;

namespace UnityClassCS
{
    class  Player
    {
        private int m_nExp;
        protected int m_nLv;
        private int m_nHP;
        private int m_nStr;

        public void Attack(Player target)
        {
            target.m_nHP = target.m_nHP - this.m_nStr;
        }

        public bool Death()
        {
            if (m_nHP <= 0)
                return true;
            else
                return false;
        }

        public void Display()
        {
            Console.WriteLine("Lv/Exp:{0},{1}",m_nLv,m_nExp);
            Console.WriteLine("HP:" + m_nHP);
            Console.WriteLine("Str:" + m_nStr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BattleMain();
        }

        static void BattleMain()
        {
            Player player = new Player();
            Player monster = new Player();
            player.Display();
            monster.Display();
            while(true)
            {
                if(player.Death() == false)
                {
                    player.Attack(monster);
                    monster.Display();
                }
                else
                {
                    Console.WriteLine("Monster Win!");
                    break;
                }
                if(monster.Death() == false)
                {
                    monster.Attack(player);
                    player.Display();
                }
                else
                {
                    Console.WriteLine("Player Win!");
                    break;
                }
            }
        }
    }
}
