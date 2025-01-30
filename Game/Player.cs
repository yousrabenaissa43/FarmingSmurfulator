using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FarmingSmurfulator.Game
{
    public class Player
    {
        private char[,] _board {  get; set; }
        private string _name {  get; set; }
        private int _money { get; set; }
        public Queue<List<string>> ActionQueue {  get; private set; }

        public Player(char[,] board, string name, int initialMoney)
        {
            _board = board;
            _name = name;
            _money = initialMoney;
            ActionQueue = new Queue<List<string>>();
             
        }
        public string DisplayInfo()
        {
            return $"Player name:{_name} \nPlayer money:{_money} " ;
        }
        public bool BuyWell(int x, int y)
        {
            if (x < _board.GetLength(0) && y < _board.GetLength(1))
            {
                if (_board[x, y] == '-' && _money >= 50)
                {
                    _money -= 50;
                    _board[x, y] = 'x';
                    List<string> newAction = new List<string>
                    {
                                   "buy",
                                   "Well",
                                    x.ToString(),
                                    y.ToString()
                    };
                    ActionQueue.Enqueue(newAction);
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public bool BuySeed(string type)
        {
            if (type == "Wheat" && _money >= 10)
            {
                _money -= 10;
               
                List<string> newAction = new List<string>
                    {
                                   "buy",
                                   type,
                                
                    };
                ActionQueue.Enqueue(newAction);
                return true;
            }
            if (type == "Saffron" && _money >= 25)
            {
                _money -= 25;

                List<string> newAction = new List<string>
                    {"buy",type};
                ActionQueue.Enqueue(newAction);
                return true;
            }

            return false;
        }
        public bool TryCollectPlant(int x, int y) 
        {
            bool collected = false; 
            if (_board[x,y] == 'W')
            {
                _money += 20;
                collected = true;
            }
            if (_board[x, y] == 'S')
            {
                _money += 42;
                collected = true;
            }
            if (collected) 
            {
                List<string> newAction = new List<string>
                    {
                                   "collect",
                                   x.ToString() ,
                                   y.ToString() ,

                    };
                ActionQueue.Enqueue(newAction);

            }
            return collected;
        }
        public void CancelFirstAction()
        {
            if (ActionQueue.Count == 0) return;
            List<string> firstAction = ActionQueue.Dequeue();

            if (firstAction[0] == "buy")
            {
                if (firstAction[1] == "Well")
                {
                    int x = int.Parse(firstAction[2]);
                    int y = int.Parse(firstAction[3]);
                    _board[x, y] = '-';
                    _money += 50;
                }
                else if (firstAction[1] == "Wheat") _money += 10;
                else if (firstAction[1] == "Saffron") _money += 25;
            }
            else if (firstAction[0] == "collect")
            {
                int x = int.Parse(firstAction[1]);
                int y = int.Parse(firstAction[2]);
                _money -= _board[x, y] == 'W' ? 20 : 42;
            }
        }

    }
}
