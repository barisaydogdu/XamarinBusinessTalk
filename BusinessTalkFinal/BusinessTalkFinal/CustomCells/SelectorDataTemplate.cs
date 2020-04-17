using BusinessTalkFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BusinessTalkFinal.CustomCells
{
    public class SelectorDataTemplate : DataTemplateSelector
    {
        private readonly DataTemplate textInDataTemplate;
        private readonly DataTemplate textOutDataTemplate;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as SignalrUser;
            if (messageVm == null)
                return null;
            return messageVm.IsTextIn ? this.textInDataTemplate : this.textOutDataTemplate;
        }


        public SelectorDataTemplate()
        {
            this.textInDataTemplate = new DataTemplate(typeof(TextInViewCell));
            this.textOutDataTemplate = new DataTemplate(typeof(TextOutViewCell));
        }

    }
}
