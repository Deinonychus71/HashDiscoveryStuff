using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace BruteForceHash.GUI.Helpers
{
    public class ComboBoxWidthBehavior : Behavior<ComboBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += OnLoaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var desiredWidth = AssociatedObject.DesiredSize.Width;

            // Create the peer and provider to expand the comboBox in code behind. 
            var peer = new ComboBoxAutomationPeer(AssociatedObject);
            if (peer.GetPattern(PatternInterface.ExpandCollapse) is not IExpandCollapseProvider provider)
                return;

            EventHandler?[] handler = [null];    // array usage prevents access to modified closure
            handler[0] = new EventHandler(delegate
            {
                if (!AssociatedObject.IsDropDownOpen || AssociatedObject.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
                    return;

                double largestWidth = 0;
                foreach (var item in AssociatedObject.Items)
                {
                    if (AssociatedObject.ItemContainerGenerator.ContainerFromItem(item) is not ComboBoxItem comboBoxItem)
                        continue;

                    comboBoxItem.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    if (comboBoxItem.DesiredSize.Width > largestWidth)
                        largestWidth = comboBoxItem.DesiredSize.Width;
                }

                AssociatedObject.Width = desiredWidth + largestWidth;

                // Remove the event handler.
                AssociatedObject.ItemContainerGenerator.StatusChanged -= handler[0];
                AssociatedObject.DropDownOpened -= handler[0];
                provider.Collapse();
            });

            AssociatedObject.ItemContainerGenerator.StatusChanged += handler[0];
            AssociatedObject.DropDownOpened += handler[0];

            // Expand the comboBox to generate all its ComboBoxItem's. 
            provider.Expand();
        }
    }
}
