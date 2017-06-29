using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infokiosk.Models
{
    public class ExhibitsRelator
    {
        public Exhibit current { get; set; }
            public Exhibit MapIt(Exhibit e, Image i)
        {
            // Terminating call.  Since we can return null from this function
            // we need to be ready for PetaPoco to callback later with null
            // parameters
            if (e == null)
                return current;

            // Is this the same exhibit as the current one we're processing
            if (current != null && current.ExhibitId == e.ExhibitId)
            {
                // Yes, just add this Image to the current exhibit's collection of Images
                current.Images.Add(i);
                // Return null to indicate we're not done with this exhibit yet
                return null;
            }

            // This is e different exhibit to the current one, or this is the 
            // first time through and we don't have an exhibit yet

            // Save the current exhibit
            var prev = current;

            // Setup the new current exhibit
            current = e;
            current.Images = new List<Image>();
            current.Images.Add(i);

            // Return the now populated previous exhibit (or null if first time through)
            return prev;
        }
    }
}