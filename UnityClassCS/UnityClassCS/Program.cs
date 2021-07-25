using System;
using System.Collections.Generic;

namespace UnityClassCS
{
    class  Player
    {
        public string m_strName;
        private int m_nExp = 0;
        protected int m_nLv = 1;
        private int m_nHP;
        private int m_nStr;

        public Player(string name, int hp, int str)
        {
            m_strName = name;
            m_nHP = hp;
            m_nStr = str;
        }
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
            Console.WriteLine("######" + m_strName + "######");
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
            //BattleMain();
            RPGMain();
        }

        static void BattleMain()
        {
            Player player = new Player("player",100,10);
            Player monster = new Player("monster",100,10);
            player.Display();
            monster.Display();
            int nTrun = 1;
            while(true)
            {
                Console.WriteLine("###### Turn:"+nTrun+" ######");
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
                nTrun++;
            }
        }
        //게임을 시작하면 서식지를 선택해 해당몬스터와 싸우기
        //(슬라임: 늪지대, 스켈레톤: 동굴, 좀비: 무덤, 드래곤: 계곡)

        enum E_FILED { EXIT = -1, SWAMP, CAVE, GRAVE, VALLEY }

        static void RPGMain()
        {
            Player player = new Player("player", 100, 10);
            List<Player> listMonsters = new List<Player>();

            listMonsters.Add(new Player("slime", 20, 5));
            listMonsters.Add(new Player("skeleton", 50, 10));
            listMonsters.Add(new Player("zombie", 100, 10));
            listMonsters.Add(new Player("dragon", 200, 540));

            int nInputFiled = 0;
            while (nInputFiled != -1)
            {
                for (int i = 0; i < listMonsters.Count; i++)
                    Console.WriteLine("{0}:{1}", i, ((E_FILED)i).ToString());
                nInputFiled = int.Parse(Console.ReadLine());

                switch (nInputFiled)
                {
                    case 0:
                        Console.WriteLine("&d,", nInputFiled.ToString());
                        BattleMain(player, listMonsters[0]);
                        break;
                    case 1:
                        Console.WriteLine("&d,", nInputFiled.ToString());
                        BattleMain(player, listMonsters[1]);
                        break;
                    case 2:
                        Console.WriteLine("&d,", nInputFiled.ToString());
                        BattleMain(player, listMonsters[2]);
                        break;
                    case 3:
                        Console.WriteLine("&d,", nInputFiled.ToString());
                        BattleMain(player, listMonsters[3]);
                        break;

                }
            }
        }

        static void BattleMain(Player player, Player monster)
        {
            player.Display();
            monster.Display();
            int nTrun = 1;
            while (true)
            {
                Console.WriteLine("###### Turn:" + nTrun + " ######");
                if (player.Death() == false)
                {
                    player.Attack(monster);
                    monster.Display();
                }
                else
                {
                    Console.WriteLine("Monster Win!");
                    break;
                }
                if (monster.Death() == false)
                {
                    monster.Attack(player);
                    player.Display();
                }
                else
                {
                    Console.WriteLine("Player Win!");
                    break;
                }
                nTrun++;
            }
        }
    }
}
