using Abp.Web.Mvc.Views;

namespace Bursify.Web.Views
{
    public abstract class BursifyWebViewPageBase : BursifyWebViewPageBase<dynamic>
    {

    }

    public abstract class BursifyWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected BursifyWebViewPageBase()
        {
            LocalizationSourceName = BursifyConsts.LocalizationSourceName;
        }
    }
}