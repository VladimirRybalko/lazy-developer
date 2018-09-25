public static UIElement FindUid(this DependencyObject parent, string uid)
{
    var count = VisualTreeHelper.GetChildrenCount(parent);

    for (int i = 0; i < count; i++)
    {
        var el = VisualTreeHelper.GetChild(parent, i) as UIElement;
        if (el == null) continue;

        if (el.Uid == uid) return el;

        el = el.FindUid(uid);
        if (el != null) return el;
    }

    if (parent is ContentControl)
    {
        UIElement content = (parent as ContentControl).Content as UIElement;
        if (content != null)
        {
            if (content.Uid == uid) return content;

            var el = content.FindUid(uid);
            if (el != null) return el;
        }
    }
    return null;
}