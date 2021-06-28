using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlatformScaleWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            if (!UseMetricWeightsCheckBox.Checked)
            {
                if (Int32.TryParse(InputSteerTextBox.Text, out Int32 SteerAxle))
                {
                    ImperialSteersLabel.Text = SteerAxle.ToString("#####");
                    MetricSteersLabel.Text = (SteerAxle / 2.2046).ToString("#####");

                    if (Int32.TryParse(InputSteerAndDrivesTextBox.Text, out Int32 BothAxles))
                    {
                        Int32 DriveAxles = BothAxles - SteerAxle;
                        ImperialDrivesLabel.Text = DriveAxles.ToString("#####");
                        MetricDrivesLabel.Text = (DriveAxles / 2.2046).ToString("#####");

                        if (Int32.TryParse(InputGrossTextBox.Text, out Int32 Gross))
                        {
                            Int32 TrailerAxle = Gross - BothAxles;
                            ImperialTrailerLabel.Text = TrailerAxle.ToString();
                            MetricTrailerLabel.Text = (TrailerAxle / 2.2046).ToString("#####");
                            ImperialGrossLabel.Text = Gross.ToString("#####");
                            MetricGrossLabel.Text = (Gross / 2.2046).ToString("#####");

                        }
                        else
                        {
                            SetFocus(InputGrossTextBox);
                        }
                    }
                    else
                    {
                        SetFocus(InputSteerAndDrivesTextBox);
                    }
                }
                else
                {
                    SetFocus(InputSteerTextBox);
                }
            }
            else
            {
                // Converting Kilograms to pounds is multiplying kilograms by 2.2046
                //Converting Pounds to kilograms is dividing pounds by 2.2046

                // THis is the checkbox enabled code for metric weight inputs
                
                if (Int32.TryParse(InputSteerTextBox.Text, out Int32 SteerAxle))
                {
                    ImperialSteersLabel.Text = (SteerAxle * 2.2046).ToString("#####");
                    MetricSteersLabel.Text = SteerAxle.ToString("#####");

                    if (Int32.TryParse(InputSteerAndDrivesTextBox.Text, out Int32 BothAxles))
                    {
                        Int32 DriveAxles = BothAxles - SteerAxle;
                        ImperialDrivesLabel.Text = (DriveAxles * 2.2046).ToString("#####");
                        MetricDrivesLabel.Text = DriveAxles.ToString("#####");

                        if (Int32.TryParse(InputGrossTextBox.Text, out Int32 Gross))
                        {
                            Int32 TrailerAxle = Gross - BothAxles;
                            ImperialTrailerLabel.Text = (TrailerAxle * 2.2046).ToString("#####");
                            MetricTrailerLabel.Text = TrailerAxle.ToString("#####");
                            ImperialGrossLabel.Text = (Gross * 2.2046).ToString("#####");
                            MetricGrossLabel.Text = Gross.ToString("#####");

                        }
                        else
                        {
                            SetFocus(InputGrossTextBox);
                        }
                    }
                    else
                    {
                        SetFocus(InputSteerAndDrivesTextBox);
                    }
                }
                else
                {
                    SetFocus(InputSteerTextBox);
                }
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            ClearInputs(Page.Controls);
        }
        void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox) 
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }

            foreach (Control ctrl in ctrls)
            {
                if (ctrl is Label)
                    ((Label)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }

            UseMetricWeightsCheckBox.Checked = false;
        }

        protected void ExitButton_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.open('close.html', '_self', null);", true);
            //Form.Dispose();
        }

        protected void InfoButton_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Messagebox", "alert('Standard max weights for Canada are 5500, 17000 and 17000 respectively with a gross of 39500.                                                 U.S. max weights for 5 axle without permit are 12000, 34000 and 34000 with a gross of 80000.                                                         A typical rule of thumb for moving axles is as follows;  Fifth Wheel per hole moves approx. 500lbs and Trailer axles per hole move approx. 250lbs.');", true);
        }
    }
}