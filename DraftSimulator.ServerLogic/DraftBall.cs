using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DraftSimulator.ServerLogic
{
    public class DraftBall
    {
        // Attributes for the class.
        private int[] _DraftBallNumber;
        public int[] DraftBallNumber
        {
            get
            {
                return this._DraftBallNumber;
            }
            set
            {
                this._DraftBallNumber = value;
            }
        }


        private int[] _LookupArray;
        public const int NumOfEligibleTeams = 14;
        public const int NumOfBallsInSequence = 4;


        // Constructors
        public DraftBall()
        {
            _DraftBallNumber = DraftBallGenerator(1);
        }

        public DraftBall(int NumberOfBalls)
        {
            _LookupArray = InitializeMasterLookupArray(NumOfEligibleTeams);
            _DraftBallNumber = DraftBallGenerator(NumberOfBalls);

        }

        // Public Methods
        public int[] DraftBallGenerator(int NumOfBalls)
        {
            Random Selected = new Random();
            int[] DraftBallSequence = new int[NumOfBalls];
            int DraftBallValue = 0;

            int[] DupsArray = new int[NumOfBalls];

            if (NumOfBalls == 1)
                DraftBallSequence[0] = Selected.Next() % NumOfEligibleTeams + 1;
            else
            {

                for (int i = 0; i < NumOfBalls; i++)
                {
                    DraftBallValue = Selected.Next() % NumOfEligibleTeams + 1;

                    while ((_LookupArray[DraftBallValue - 1] == 0))
                    {
                        DraftBallValue = Selected.Next() % NumOfEligibleTeams + 1;
                    }

                    _LookupArray[DraftBallValue - 1] = 0;
                    DraftBallSequence[i] = DraftBallValue;
                }
                
            }
            Array.Sort(DraftBallSequence);
           
            return DraftBallSequence;
        }

        // Private Helper Methods

        private int[] InitializeMasterLookupArray(int NumberOfBalls)
        {
            int[] LookupArray = new int[NumberOfBalls];
            for (int i = 0; i < NumberOfBalls; i++)
            {
                LookupArray[i] = i + 1;
            }
            

            return LookupArray;

        }

       
    }
}
