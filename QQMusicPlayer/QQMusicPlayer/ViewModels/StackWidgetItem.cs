using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QQMusicPlayer.ViewModels
{
    class StackWidget
    {
        private readonly Type _contentType;
        private object? _dataContext;
        public object DataContext
        {
            get
            {
                return _dataContext;
            }
            set
            {
                _dataContext = value;
            }
        }
        private object? _content;
        public string Name { get; }
        public object? Content => _content ??= CreateContent();

        public StackWidget(string name, Type contentType, object? dataContext = null)
        {
            Name = name;
            _contentType = contentType;
            _dataContext = dataContext;

        }

        private object? CreateContent()
        {
            var content = Activator.CreateInstance(_contentType);
            if (_dataContext != null && content is FrameworkElement element)
            {
                element.DataContext = _dataContext;
            }

            return content;
        }
    }
}
