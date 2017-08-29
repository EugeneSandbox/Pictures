using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Pictures.WebPart.PictureService;



namespace Pictures.WebPart.PictureGalary
{
    [ToolboxItemAttribute(false)]
    public partial class PictureGalary : System.Web.UI.WebControls.WebParts.WebPart
    {
        private const string routePath = "/rest/pictures";
        private readonly Service _pictureService = new Service();


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            label.Text = _pictureService.Url;
            var picturesCollection = _pictureService.GetAll();
            foreach (var picture in picturesCollection)
                picture.Image = _pictureService.Url + routePath + "/" + picture.Id;

            picturesGalary.DataSource = picturesCollection;
            picturesGalary.DataBind();
        }
    }
}
