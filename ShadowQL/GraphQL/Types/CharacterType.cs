using GraphQL.Types;
using ShadowQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowQL.GraphQL.Types
{
    public class CharacterType: ObjectGraphType<Character> 
    {
        public CharacterType()
        {
            Field(t => t.Id);
            Field(t => t.PlayerId).Description("IRL player who owns this character.");
            Field(t => t.FirstName, nullable: true).Description("Something you share with your closest friends.");
            Field(t => t.LastName, nullable: true).Description("Something you only share if you wanna get fragged.");
            Field(t => t.Handle, nullable: true).Description("What people who like call you.  What people who hate call you.  What am I saying?  Only the people who know you call you this, and let's face it.  There's probably not many of 'em, chummer!");
            Field(t => t.Age, nullable: true).Description("It's more than a mindset - especially for Trogs!");
            Field(t => t.Strength, nullable: true).Description("You lift, brah?");
            Field(t => t.Agility, nullable: true).Description("How fast and flexible you are.");
            Field(t => t.Willpower, nullable: true).Description("Can you hold it together when the drek hits the fan?");
            Field(t => t.Logic, nullable: true).Description("Are you the sharpest tool in the shed - or just the most dangerous?");
            Field(t => t.Charisma, nullable: true).Description("Your charming personality, of course!");
            Field(t => t.Edge, nullable: true).Description("Feelin' lucky... Are ya?  Chummer?");
            Field(t => t.IsAwakened, nullable: true).Description("For those who do the magics.");
            Field(t => t.IsEmerged, nullable: true).Description("Tech wizards.  And I'm not talkin' 'bout plain ole deckers.");
            Field(t => t.Essence, nullable: true).Description("The anchor for your soul to this mortal coil.");
            Field(t => t.Karma, nullable: true).Description("Reflects the impact you've had on the world, and how much you should get back - unless you get fragged first.");
            Field(t => t.KarmaBalance, nullable: true).Description("What you've got in your celestial karma account.  Not everyone makes a withdrawl, though.");
        }
    }
}
