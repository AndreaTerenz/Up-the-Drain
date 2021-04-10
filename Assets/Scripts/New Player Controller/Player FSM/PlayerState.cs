using System;
using UnityEngine;

namespace New_Player_Controller.Player_FSM
{
    public abstract class PlayerStateMachine : MonoBehaviour
    {
        private PlayerState _state;
        public PlayerState State
        {
            get => _state;
            set
            {
                _state = value;
                _state.Start();
            }
        }

        protected void Start()
        {
            State = new StandardState();
        }
    }
    
    public abstract class PlayerState
    {
        public abstract void Start();
    }

    public class StandardState : PlayerState
    {
        public override void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}