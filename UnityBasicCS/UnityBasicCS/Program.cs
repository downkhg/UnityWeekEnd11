using System;
using System.Collections.Generic;

namespace UnityBasicCS
{
    class Program
    {
        static void Main(string[] args)
        {//구문
            Console.WriteLine("Hello World!");
            Console.WriteLine("KHG");
            Console.WriteLine("Add:" + Add(10, 20));
            //ValMain();
            //PlayerMonsterAttackMain();
            //CritcalAttackMain();
            //PlayerAttackWhileMain();
            BattleeMain();
        }//구문끝
        //정수: 셀수있는수(음수,양수)
        //실수: 단위보다 작은 값도 표현할수있는 수
        static int Add(int a, int b)//10,20
        {
            int c = a + b; //30 = 10+20
            return c; //30
        }

        static void ValMain()
        {
            int nScore = 0;
            //float fRat = 1.0f / 4.0f; //0.25
            float fRat = (float)(1 / 4); //0.25

            Console.WriteLine("Score:" + nScore);
            Console.WriteLine("Rat:" + fRat);
        }

        //플레이어가 몬스터에게 공격하기
        //플레이어가 몬스터를 공격하면 (몬스터의 체력)이 (일정수치:플레이어의 공격력)만큼 감소한다.
        //공격?
        //데이터(재료): 몬스터의 체력,플레이어의 공격력 -> 변수:정수
        //알고리즘(레시피): 공격한다 -> 몬스터의 체력 - 플레이어의 공격력
        static void PlayerMonsterAttackMain()
        {
            int nPlayerAttack = 10;
            int nMonsterHP = 100;
            Console.WriteLine("1.MonsterHP:" + nMonsterHP);
            Console.WriteLine("1.PlayerAttack:" + nPlayerAttack);
            nMonsterHP = nMonsterHP - nPlayerAttack;
            Console.WriteLine("2.MonsterHP:"+ nMonsterHP);
            Console.WriteLine("2.PlayerAttack:" + nPlayerAttack);
        }
        //플레이어가 몬스터에게 공격하는데 일정확률로 크리티컬이 발생한다.
        //플레이어가 몬스터에게 공격하는데 랜덤(일정확률:준비한숫자중 1개를 뽑을 확률)로 크리티컬(원래의 공격력보다 더 큰데미지)이 발생한다.
        //데이터(재료): 몬스터의 체력,플레이어의 공격력 -> 변수:정수
        //알고리즘(레시피): 공격한다 -> 몬스터의 체력 - 플레이어의 공격력
        static void CritcalAttackMain()
        {
            int nPlayerAttack = 10;
            int nMonsterHP = 100;
            Console.WriteLine("1.MonsterHP:" + nMonsterHP);
            Console.WriteLine("1.PlayerAttack:" + nPlayerAttack);
            Random cRandom = new Random();
            int nRandom = cRandom.Next(0, 3);
            Console.WriteLine("Random:" + nRandom);

            if(nRandom == 1)//1~3:50%, 0~3:33.33%
            {
                nMonsterHP = nMonsterHP - (int)((float)nPlayerAttack *1.5f);
                Console.WriteLine("Critcal!!!");
            }
            else//0,2
            {
                nMonsterHP = nMonsterHP - nPlayerAttack;
            }
            Console.WriteLine("2.MonsterHP:" + nMonsterHP);
            Console.WriteLine("2.PlayerAttack:" + nPlayerAttack);
        }
        //가고싶은곳을 입력하면, 해당위치의 이름을 출력한다.(단, 이동가능장소는 마을,상점,필드)
        //데이터: 입력, 이동가능장소 마을,상점,필드
        //알고리즘: 가고싶은곳을 입력하면, 해당위치의 이름을 출력한다.
        void StageMain()
        {
            string strInput;
            Console.Write("Input Stage:");
            strInput = Console.ReadLine();
            ////출력결과는 같으나 예외처리를 할수없다.
            //Console.WriteLine("Here is " + strInput); 

            switch (strInput)
            {
                case "Town":
                    Console.WriteLine("Here is Town");
                    break;
                case "Shop":
                    Console.WriteLine("Here is Shop");
                    break;
                case "Filed":
                    Console.WriteLine("Here is Filed");
                    break;
                default:
                    Console.WriteLine("!?!?!?!?!?!!?");
                    break;
            }
        }
        //플레이어가 몬스터가 (죽을때:체력이 0이하)까지 공격한다.
        //플레이어가 몬스터가 (살아있으면) 공격한다.
        static void PlayerAttackWhileMain()
        {
            int nPlayerAttack = 10;
            int nMonsterHP = 100;
            //while (nMonsterHP <= 0) //100 <= 0 -> F
            //while(true)
            while(nMonsterHP > 0)//종료조건의 반대조건을 준다.
            {
                Console.WriteLine("1.MonsterHP:" + nMonsterHP);
                Console.WriteLine("1.PlayerAttack:" + nPlayerAttack);
                nMonsterHP = nMonsterHP - nPlayerAttack;
                Console.WriteLine("2.MonsterHP:" + nMonsterHP);
                Console.WriteLine("2.PlayerAttack:" + nPlayerAttack);
                //if (nMonsterHP <= 0) break;//hp가 0이되면 중단한다.
            }
        }
        //(플레이어:체력,공격력)나 (몬스터:체력,공격력)가 전투한다.(둘중 하나가 쓰러질때까지 공격한다.)
        //플레이어가 공격하면 몬스터는 반격한다. -> 한쪽이 죽을때까지
        //(단, 플레이어나 몬스터가 죽으면 공격할수없다.)
        static void BattleeMain()
        {
            int nPlayerAttack = 10;
            int nPlayerHP = 100;
           
            int nMonsterAttack = 10;
            int nMonsterHP = 100;

            Console.WriteLine("1.PlayerHP:" + nMonsterHP);
            Console.WriteLine("1.PlayerAttack:" + nPlayerAttack);
            Console.WriteLine("1.MonsterHP:" + nPlayerHP);
            Console.WriteLine("1.MonsterAttack:" + nPlayerAttack);
            //while (nMonsterHP <= 0) //100 <= 0 -> F
            //while(true)
            while (nMonsterHP > 0)//종료조건의 반대조건을 준다.
            {
                if (nPlayerHP > 0)
                {
                    Console.WriteLine("1.MonsterHP:" + nMonsterHP);
                    nMonsterHP = nMonsterHP - nPlayerAttack;
                    Console.WriteLine("2.MonsterHP:" + nMonsterHP);
                }
                else
                    Console.WriteLine("Monster Win!!");

                if (nMonsterHP > 0)
                {
                    Console.WriteLine("1.PlayerHP:" + nMonsterHP);
                    nPlayerHP = nPlayerHP - nMonsterAttack;
                    Console.WriteLine("2.PlayerHP:" + nMonsterHP);
                    //if (nMonsterHP <= 0) break;//hp가 0이되면 중단한다.
                }
                else
                    Console.WriteLine("Player Win!!");
            }
        }
        //몬스터의 종류는, 슬라임,스켈레톤,좀비,드래곤가 있고 이 정보를 저장하는 리스트를 작성하여라
        static void MonsterMain()
        {
            List<string> listMonster = new List<string>();

            listMonster.Add("Slime"); //0
            listMonster.Add("Skeleton"); //1
            listMonster.Add("Zombie"); //2
            listMonster.Add("Dragon"); //3

            Console.WriteLine("[0]:" + listMonster[0]);
            Console.WriteLine("[3]:" + listMonster[3]);

            for(int i = 0; i<listMonster.Count; i++)
            {
                Console.WriteLine("["+i+"]:" + listMonster[i]);
            }
        }
    }
}
