﻿//-----------------------------------------------------------------------------
// <copyright file="Score.cs" company="WheelMUD Development Team">
//   Copyright (c) WheelMUD Development Team.  See LICENSE.txt.  This file is 
//   subject to the Microsoft Public License.  All other rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

namespace WheelMUD.Actions
{
    using System.Collections.Generic;
    using WheelMUD.Core;
    using WheelMUD.Core.Attributes;
    using WheelMUD.Interfaces;

    /// <summary>A command to list the player's character sheet.</summary>
    /// <remarks>@@@ TODO: Implement beyond 'Attributes.cs' functionality.</remarks>
    [ExportGameAction]
    [ActionPrimaryAlias("score", CommandCategory.Player)]
    [ActionAlias("character sheet", CommandCategory.Player)]
    [ActionAlias("charactersheet", CommandCategory.Player)]
    [ActionAlias("char sheet", CommandCategory.Player)]
    [ActionAlias("charsheet", CommandCategory.Player)]
    [ActionAlias("character", CommandCategory.Player)]
    [ActionAlias("sco", CommandCategory.Player)]
    [ActionDescription("See your stats.")]
    [ActionSecurity(SecurityRole.player)]
    public class Score : GameAction
    {
        /// <summary>List of reusable guards which must be passed before action requests may proceed to execution.</summary>
        private static readonly List<CommonGuards> ActionGuards = new List<CommonGuards>
        {
        };

        /// <summary>Executes the command.</summary>
        /// <param name="actionInput">The full input specified for executing the command.</param>
        public override void Execute(ActionInput actionInput)
        {
            IController sender = actionInput.Controller;
            sender.Write(Renderer.Instance.RenderScore(sender.Thing));
        }

        /// <summary>Checks against the guards for the command.</summary>
        /// <param name="actionInput">The full input specified for executing the command.</param>
        /// <returns>A string with the error message for the user upon guard failure, else null.</returns>
        public override string Guards(ActionInput actionInput)
        {
            string commonFailure = this.VerifyCommonGuards(actionInput, ActionGuards);
            if (commonFailure != null)
            {
                return commonFailure;
            }

            return null;
        }
    }
}