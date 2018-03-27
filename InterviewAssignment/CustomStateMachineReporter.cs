using Appccelerate.StateMachine.Machine;
using System;
using System.Collections.Generic;

namespace InterviewAssignment
{

    /// <summary>
    /// Provides way to customize state reporting.
    /// 
    /// By default you cannot get container of states from Appccelerate state machine.
    /// This class can be used for that. Also it has StateToString method to enable
    /// printing hierarchical states.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TEvent"></typeparam>
    public class CustomStateMachineReporter<TState, TEvent> : IStateMachineReport<TState, TEvent>
            where TState : IComparable
    where TEvent : IComparable

    {
        IEnumerable<IState<TState, TEvent>> myStates;

        public IEnumerable<IState<TState, TEvent>> States
        {
            get
            {
                return myStates;
            }
        }

        public void Report(string name, IEnumerable<IState<TState, TEvent>> states, Initializable<TState> initialStateId)
        {
            myStates = states;
        }

        public string StateToString(TState state, string separator = ".")
        {

            //Your assignment is here!
            //Tip: You find state machine hierarchy on States property (or myStates field). 
            //You should go through the states and print that on what hierarchy path the current state
            //is found. So if state is Initializing this method should return "Down.Initializing" because
            //"Initializing" is substate of "Down".
             string StateinString = String.Empty;
            string HelpString = String.Empty;


            
                
            foreach (var item in myStates)
                {
                    if (item.Id.Equals(state))
                    {
                        foreach (var item2 in myStates)
                        {
                            if (item2.Id.Equals(state))
                            {
                            //Try if Superstate Superstate has content
                                try
                                {
                                    HelpString = item2.SuperState.SuperState.ToString() + separator;
                                }
                                catch { };
                            }
                        }
                        
                        StateinString = HelpString + item.SuperState.ToString() + separator + item.Id.ToString();
                        
                    }
                }

            
           

           
            return StateinString;
        }
    }
}
