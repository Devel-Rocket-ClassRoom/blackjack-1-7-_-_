using System;
using System.Collections.Generic;
using System.Text;
internal class Blackjack
{
    public readonly string[] CardNumbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public readonly string[] CardSuits = { "♠", "♡", "◇", "♣" };

    public int[] CurrDeck;

    public int Counter;

    public int CurrentCoin; //플레이중 변경되는 코인

    public readonly int MaxCoin=1000; //시작시 가지고있는 코인

    public int InputCoin;//입력받은 코인값 저장
  


    public Blackjack()
    {
        CurrentCoin = MaxCoin; //코인을 1000으로 초기화
        NewDeck();
    }
      


    private void NewDeck()
    {

        CurrDeck = new int[52];

        Counter = 0;

        Console.WriteLine("카드를 섞는 중...");

        for (int i = 0; i < CurrDeck.Length; i++)
        {
            CurrDeck[i] = i;
        }

        for (int i = CurrDeck.Length - 1; i > 0; i--)
        {
            Random random = new Random();
            int x = random.Next(0, i + 1);

            int temp = CurrDeck[i];
            CurrDeck[i] = CurrDeck[x];
            CurrDeck[x] = temp;
        }

    }
    public int Draw()
    {
        if (Counter > CurrDeck.Length - 1)
        {
            Console.WriteLine("새로운 덱을 열었습니다");
            NewDeck();
        }
       return CurrDeck[Counter++];
    }


    
    public void ShowDealer(Dealer dealer)
    {
        string cardSuit;
        string cardNumber;

        Console.Write($"딜러의 패: ");
        for (int i = 0; i < dealer.Counter; i++)
        {
            cardSuit = CardSuits[dealer.Hands[i] / 13];
            cardNumber = CardNumbers[dealer.Hands[i] % 13];
            if (!dealer.IsOpened && i == 0)
            {
                Console.Write($"[??] ");
            }
            else
            {
                Console.Write($"[{cardSuit} {cardNumber}] ");
            }
        }
      
        Console.WriteLine();
        Console.Write($"딜러 점수: {(dealer.IsOpened ? dealer.Score : " ??")}");
       

    }

    public void ShowPlayer(Player player)
    {
        string cardSuit;
        string cardNumber;

        Console.Write($"플레이어의 패: ");
        for (int i = 0; i < player.Counter; i++)
        {
            cardSuit = CardSuits[player.Hands[i] / 13];
            cardNumber = CardNumbers[player.Hands[i] % 13];
            
                Console.Write($"[{cardSuit} {cardNumber}] ");
          
        }
        Console.WriteLine();
        Console.WriteLine($"플레이어 점수: {player.Score}");

    }


    public void secretcard(Dealer dealer)//이게 새로만든 매소드 입니다.
    { 
        int i = 0;
        string cardSuit;
        string cardNumber;
        cardSuit = CardSuits[dealer.Hands[i] / 13];
        cardNumber = CardNumbers[dealer.Hands[i] % 13];
        Console.WriteLine($"딜러의 숨겨진 카드: [{cardSuit} {cardNumber}]");
    }


    public void Betting() //배팅값을 사용자에게 받은후 검사
    {
        Console.WriteLine($"보유 칩: {CurrentCoin}");

     
        while(true)
            {
            Console.Write($"베팅 금액을 입력하세요: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int inputcoin);

            if (inputcoin > CurrentCoin)
            {
                Console.WriteLine();
                Console.WriteLine($"보유금액을 초과했습니다");
                Console.WriteLine($"다시 입력해 주세요");
                Console.WriteLine();
            }
            else if (inputcoin < 0)
            {
                Console.WriteLine();
                Console.WriteLine($"0이하의 금액을 배팅할수 없습니다");
                Console.WriteLine($"다시 입력해 주세요");
                Console.WriteLine();
            }
            else if (inputcoin <= CurrentCoin && inputcoin > 0)
            {
                Console.WriteLine();
                InputCoin = inputcoin;
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"배팅할 금액을 입력해 주세요");
                Console.WriteLine();
            }

            }
    }




}

