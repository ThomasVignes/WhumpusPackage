using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whumpus
{
    public class AnimationEvents : MonoBehaviour
    {
        public List<AnimatorEvent> AnimatorEvents = new List<AnimatorEvent>();

        public void PlayEvent(string name)
        {
            foreach (var e in AnimatorEvents)
            {
                if (e.Name == name)
                {
                    e.Delegate.Invoke();
                    return;
                }
            }
        }
    }
}
