﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMonsterClass
{
    class SeaMonster
    {
        public enum EmotionalState
        {
            NONE,
            HAPPY,
            SAD,
            ANGRY,
            PISSED,
            FURIOUS,
            WILD
        }


        #region Fields
        //Fields
        private string _name;
        private double _weight;
        private bool _canUseFreshwater;
        private EmotionalState _currentEmotionalState;
        private string _homeSea;



        #endregion

        #region PROPERTIES
        //Properties
        public bool CanUseFreshwater
        {
            get { return _canUseFreshwater; }
            set { _canUseFreshwater = value; }
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public EmotionalState CurrentEmotionalState
        {
            get { return _currentEmotionalState; }
            set { _currentEmotionalState = value; }
        }

        public string HomeSea
        {
            get { return _homeSea; }
            set { _homeSea = value; }
        }


        #endregion

        #region METHODS
        //METHODS
        public string SeaMonsterAttitude()
        {

            return _name + " is " + _currentEmotionalState + ".";
        }

        #endregion
        #region CONSTRUCTORS
        //Constructor
        public SeaMonster()
        {

        }

        public SeaMonster(string name)
        {
            _name = name;
        }
        #endregion 
    }
}
