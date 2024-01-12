using UnityEngine;
using ServiceLocator.Utilities;
/**  This script demonstrates implementation of the Observer Pattern.
  *  If you're interested in learning about Observer Pattern, 
  *  you can find a dedicated course on Outscal's website.
  *  Link: https://outscal.com/courses
  **/

namespace ServiceLocator.Events
{
    public class EventService : GenericSingleton<EventService>
    {
        public GameEventController<int> OnMapSelected { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            OnMapSelected = new GameEventController<int>();
        }
        
    }
}