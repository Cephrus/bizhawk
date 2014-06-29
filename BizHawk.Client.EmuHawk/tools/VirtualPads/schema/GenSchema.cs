﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using BizHawk.Client.Common;
using BizHawk.Emulation.Cores.Consoles.Sega.gpgx;

namespace BizHawk.Client.EmuHawk
{
	[SchemaAttributes("GEN")]
	public class GenSchema : IVirtualPadSchema
	{
		public IEnumerable<PadSchema> GetPadSchemas()
		{
			var devs = ((GPGX)Global.Emulator).GetDevices();
			int player = 1;
			foreach (var dev in devs)
			{
				switch (dev)
				{
					case LibGPGX.INPUT_DEVICE.DEVICE_NONE:
						continue; // do not increment player number because no device was attached
					case LibGPGX.INPUT_DEVICE.DEVICE_PAD3B:
						yield return ThreeButtonController(player);
						break;
					case LibGPGX.INPUT_DEVICE.DEVICE_PAD6B:
						yield return SixButtonController(player);
						break;
					case LibGPGX.INPUT_DEVICE.DEVICE_LIGHTGUN:
						yield return LighGun(player);
						break;
					case LibGPGX.INPUT_DEVICE.DEVICE_MOUSE:
						yield return Mouse(player);
						break;
					case LibGPGX.INPUT_DEVICE.DEVICE_XE_A1P:
					default:
						// TO DO
						break;
				}

				player++;
			}

			yield return ConsoleButtons();
		}

		public static PadSchema ThreeButtonController(int controller)
		{
			return new PadSchema
			{
				IsConsole = false,
				DefaultSize = new Size(174, 90),
				Buttons = new[]
				{
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Up",
						DisplayName = "",
						Icon = Properties.Resources.BlueUp,
						Location = new Point(14, 12),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Down",
						DisplayName = "",
						Icon = Properties.Resources.BlueDown,
						Location = new Point(14, 56),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Left",
						DisplayName = "",
						Icon = Properties.Resources.Back,
						Location = new Point(2, 34),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Right",
						DisplayName = "",
						Icon = Properties.Resources.Forward,
						Location = new Point(24, 34),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " A",
						DisplayName = "A",
						Location = new Point(98, 40),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " B",
						DisplayName = "B",
						Location = new Point(122, 40),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " C",
						DisplayName = "C",
						Location = new Point(146, 40),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Start",
						DisplayName = "S",
						Location = new Point(122, 12),
						Type = PadSchema.PadInputType.Boolean
					}
				}
			};
		}

		public static PadSchema SixButtonController(int controller)
		{
			return new PadSchema
			{
				IsConsole = false,
				DefaultSize = new Size(174, 90),
				Buttons = new[]
				{
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Up",
						DisplayName = "",
						Icon = Properties.Resources.BlueUp,
						Location = new Point(14, 12),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Down",
						DisplayName = "",
						Icon = Properties.Resources.BlueDown,
						Location = new Point(14, 56),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Left",
						DisplayName = "",
						Icon = Properties.Resources.Back,
						Location = new Point(2, 34),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Right",
						DisplayName = "",
						Icon = Properties.Resources.Forward,
						Location = new Point(24, 34),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " A",
						DisplayName = "A",
						Location = new Point(98, 40),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " B",
						DisplayName = "B",
						Location = new Point(122, 40),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " C",
						DisplayName = "C",
						Location = new Point(146, 40),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " X",
						DisplayName = "X",
						Location = new Point(98, 65),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Y",
						DisplayName = "Y",
						Location = new Point(122, 65),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Z",
						DisplayName = "Z",
						Location = new Point(146, 65),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Start",
						DisplayName = "S",
						Location = new Point(122, 12),
						Type = PadSchema.PadInputType.Boolean
					}
				}
			};
		}

		public static PadSchema LighGun(int controller)
		{
			return new PadSchema
			{
				DisplayName = "Light Gun",
				IsConsole = false,
				DefaultSize = new Size(356, 260),
				MaxSize = new Size(356, 260),
				Buttons = new[]
				{
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Lightgun X",
						Location = new Point(14, 17),
						Type = PadSchema.PadInputType.TargetedPair,
						TargetSize = new Size(256, 240),
						SecondaryNames = new []
						{
							"P" + controller + " Lightgun Y",
							"P" + controller + " Lightgun Trigger",
						}
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Lightgun Trigger",
						DisplayName = "Trigger",
						Location = new Point(284, 17),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Lightgun Start",
						DisplayName = "Start",
						Location = new Point(284, 40),
						Type = PadSchema.PadInputType.Boolean
					}
				}
			};
		}

		public static PadSchema Mouse(int controller)
		{
			return new PadSchema
			{
				DisplayName = "Mouse",
				IsConsole = false,
				DefaultSize = new Size(400, 290),
				Buttons = new[]
				{
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Mouse X",
						Location = new Point(14, 17),
						Type = PadSchema.PadInputType.TargetedPair,
						TargetSize = new Size(320, 270),
						SecondaryNames = new []
						{
							"P" + controller + " Mouse Y",
							"P" + controller + " Mouse Left",
						}
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Mouse Left",
						DisplayName = "Left",
						Location = new Point(335, 17),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Mouse Center",
						DisplayName = "Center",
						Location = new Point(335, 40),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Mouse Right",
						DisplayName = "Right",
						Location = new Point(335, 63),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "P" + controller + " Mouse Start",
						DisplayName = "Start",
						Location = new Point(335, 86),
						Type = PadSchema.PadInputType.Boolean
					}
				}
			};
		}

		public static PadSchema ConsoleButtons()
		{
			return new PadSchema
			{
				DisplayName = "Console",
				IsConsole = true,
				DefaultSize = new Size(150, 50),
				Buttons = new[]
				{
					new PadSchema.ButtonScema
					{
						Name = "Reset",
						DisplayName = "Reset",
						Location = new Point(10, 15),
						Type = PadSchema.PadInputType.Boolean
					},
					new PadSchema.ButtonScema
					{
						Name = "Power",
						DisplayName = "Power",
						Location = new Point(58, 15),
						Type = PadSchema.PadInputType.Boolean
					}
				}
			};
		}
	}
}