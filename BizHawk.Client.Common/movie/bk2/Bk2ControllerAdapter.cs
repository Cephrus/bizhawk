﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BizHawk.Common;
using BizHawk.Emulation.Common;

namespace BizHawk.Client.Common
{
	public class Bk2ControllerAdapter : IMovieController
	{
		#region IController Implementation

		public bool this[string button]
		{
			get { return MyBoolButtons[button]; }
		}

		public bool IsPressed(string button)
		{
			return MyBoolButtons[button];
		}

		public float GetFloat(string name)
		{
			return MyFloatControls[name];
		}

		#endregion

		#region IMovieController Implementation

		public ControllerDefinition Type { get; set; }

		/// <summary>
		/// latches one player from the source
		/// </summary>
		public void LatchPlayerFromSource(IController playerSource, int playerNum)
		{
			foreach (string button in playerSource.Type.BoolButtons)
			{
				var bnp = ButtonNameParser.Parse(button);
				if (bnp == null)
				{
					continue;
				}

				if (bnp.PlayerNum != playerNum)
				{
					continue;
				}

				bool val = playerSource[button];
				MyBoolButtons[button] = val;
			}
		}

		/// <summary>
		/// latches all buttons from the provided source
		/// </summary>
		public void LatchFromSource(IController source)
		{
			foreach (string button in Type.BoolButtons)
			{
				MyBoolButtons[button] = source[button];
			}

			foreach (string name in Type.FloatControls)
			{
				MyFloatControls[name] = source.GetFloat(name);
			}
		}

		/// <summary>
		/// latches all buttons from the supplied mnemonic string
		/// </summary>
		public void SetControllersAsMnemonic(string mnemonic)
		{
			/*
			 * This doesn't work because the working dictionary is populated by setting things by name, it will always be 0 in this context
			 * Need some sort of reverse lookup
			var segments = mnemonic.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

			var keys = MyBoolButtons.Keys.Select(x => x).ToList();
			for (int i = 0; i < segments.Length; i++)
			{
				MyBoolButtons[keys[i]] = !(segments[0][i] == '.');
			}
			*/
		}

		#endregion

		private readonly WorkingDictionary<string, bool> MyBoolButtons = new WorkingDictionary<string, bool>();
		private readonly WorkingDictionary<string, float> MyFloatControls = new WorkingDictionary<string, float>();
	}
}