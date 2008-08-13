/* 
 * Copyright (c) 2003-2004, University of Maryland
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided
 * that the following conditions are met:
 * 
 *		Redistributions of source code must retain the above copyright notice, this list of conditions
 *		and the following disclaimer.
 * 
 *		Redistributions in binary form must reproduce the above copyright notice, this list of conditions
 *		and the following disclaimer in the documentation and/or other materials provided with the
 *		distribution.
 * 
 *		Neither the name of the University of Maryland nor the names of its contributors may be used to
 *		endorse or promote products derived from this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR
 * TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * Piccolo was written at the Human-Computer Interaction Laboratory www.cs.umd.edu/hcil by Jesse Grosjean
 * and ported to C# by Aaron Clamage under the supervision of Ben Bederson.  The Piccolo website is
 * www.cs.umd.edu/hcil/piccolo.
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using UMD.HCIL.PocketPiccolo;
using UMD.HCIL.PocketPiccolo.Util;
using UMD.HCIL.PocketPiccolo.Events;
using UMD.HCIL.PocketPiccolo.Activities;
//using UMD.HCIL.PocketPiccoloX.Components;
 
namespace UMD.HCIL.PocketPiccoloX {
	public delegate void ProcessDelegate();

	/// <summary>
	/// Summary description for PForm.
	/// </summary>
	public class PForm : System.Windows.Forms.Form {
		private PCanvas canvas;
		//private PScrollableControl scrollableControl;
		//private ProcessDelegate processDelegate;

		public PForm() : this(null) {
		}

		public PForm(PCanvas aCanvas) {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			if (aCanvas == null) {
				canvas = new PCanvas();
			} else {
				canvas = aCanvas;
			}

			BeforeInitialize();

			//scrollableControl = new PScrollableControl(canvas);
			//AutoScrollCanvas = false;

			//Note: If the main application form, generated by visual studio, is set to
			//extend PForm, the InitializeComponent will set the bounds after this statement
			//Bounds = DefaultFormBounds;

			//this.SuspendLayout();
			canvas.Size = DefaultCanvasSize;
			//scrollableControl.Size = ClientSize;
			//this.Controls.Add(scrollableControl);

			//scrollableControl.Anchor = 
			//	AnchorStyles.Bottom |
			//	AnchorStyles.Top |
			//	AnchorStyles.Left |
			//	AnchorStyles.Right;

			this.Controls.Add(canvas);
			//this.ResumeLayout(false);

			//FullScreenMode = fullScreenMode;

			//Force visible
			//this.Visible = true;
			//this.Refresh();

			//Necessary to invalidate the bounds because the state will be incorrect since
			//the message loop did not exist when the inpts were scheduled.
			//this.canvas.Root.InvalidateFullBounds();
			//this.canvas.Root.InvalidatePaint();

			//this.processDelegate = new ProcessDelegate(Initialize);
			//canvas.Invoke(processDelegate);

			canvas.Focus();
			Initialize();
		}

		#region Basic
		/// <summary>
		/// Gets this form's canvas.
		/// </summary>
		/// <value>This form's canvas.</value>
		public virtual PCanvas Canvas {
			get { return canvas; }
		}

		/// <summary>
		/// Gets the default canvas size to use.
		/// </summary>
		public virtual Size DefaultCanvasSize {
			get {
				return new Size(240, 294);
			}
		}
		#endregion

		#region Initialize
		/// <summary>
		/// This method will be called before the <see cref="Initialize"/> method and will
		/// be called on the thread that is constructing this object.
		/// </summary>
		public virtual void BeforeInitialize() {
		}

		/// <summary>
		/// Subclasses should override this method and add their Piccolo initialization code
		/// there.
		/// </summary>
		/// <remarks>
		/// This method will be called on the main event dispatch thread.  Note that the
		/// constructors of PForm subclasses may not be complete when this method is called.
		/// If you need to initailize some things in your class before this method is called
		/// place that code in <see cref="BeforeInitialize"/>.
		/// </remarks>
		public virtual void Initialize() {
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.Text = "PForm";
		}
		#endregion
	}
}