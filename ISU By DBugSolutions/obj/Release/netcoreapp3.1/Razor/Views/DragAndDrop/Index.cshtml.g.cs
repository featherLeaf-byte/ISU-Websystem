#pragma checksum "N:\Sidley's Project\ISU\ISU By DBugSolutions\Views\DragAndDrop\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6a257c93e52f6bca6a569afc3544b58f0c53194"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DragAndDrop_Index), @"mvc.1.0.view", @"/Views/DragAndDrop/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "N:\Sidley's Project\ISU\ISU By DBugSolutions\Views\_ViewImports.cshtml"
using ISU_By_DBugSolutions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "N:\Sidley's Project\ISU\ISU By DBugSolutions\Views\_ViewImports.cshtml"
using ISU_By_DBugSolutions.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "N:\Sidley's Project\ISU\ISU By DBugSolutions\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6a257c93e52f6bca6a569afc3544b58f0c53194", @"/Views/DragAndDrop/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b4eb1e8d92abcfb299d33d680098909f84b76bf", @"/Views/_ViewImports.cshtml")]
    public class Views_DragAndDrop_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <link rel=""shortcut icon"" href=""/TemplateData/favicon.ico"">
    <link rel=""stylesheet"" href=""/TemplateData/style.css"">
    
        <div id=""unity-container"" class=""unity-desktop"">
            <canvas id=""unity-canvas"" width=960 height=600></canvas>
            <div id=""unity-loading-bar"">
                <div id=""unity-logo""></div>
                <div id=""unity-progress-bar-empty"">
                    <div id=""unity-progress-bar-full""></div>
                </div>
            </div>
            <div id=""unity-warning""> </div>
            <div id=""unity-footer"">
                <div id=""unity-webgl-logo""></div>
          
                <div id=""unity-build-title"">Drag And Drop</div>
            </div>
        </div>

  
    <script>
        var container = document.querySelector(""#unity-container"");
        var canvas = document.querySelector(""#unity-canvas"");
        var loadingBar = document.querySelector(""#unity-loading-bar"");
        var progressBarFull = document.querySelector(""#unity-progress-ba");
            WriteLiteral(@"r-full"");
        var fullscreenButton = document.querySelector(""#unity-fullscreen-button"");
        var warningBanner = document.querySelector(""#unity-warning"");

        // Shows a temporary message banner/ribbon for a few seconds, or
        // a permanent error message on top of the canvas if type=='error'.
        // If type=='warning', a yellow highlight color is used.
        // Modify or remove this function to customize the visually presented
        // way that non-critical warnings and error messages are presented to the
        // user.
        function unityShowBanner(msg, type) {
            function updateBannerVisibility() {
                warningBanner.style.display = warningBanner.children.length ? 'block' : 'none';
            }
            var div = document.createElement('div');
            div.innerHTML = msg;
            warningBanner.appendChild(div);
            if (type == 'error') div.style = 'background: red; padding: 10px;';
            else {
                if (type == 'warning");
            WriteLiteral(@"') div.style = 'background: yellow; padding: 10px;';
                setTimeout(function () {
                    warningBanner.removeChild(div);
                    updateBannerVisibility();
                }, 5000);
            }
            updateBannerVisibility();
        }

        var buildUrl = ""/Games/Drag And Drop/Build"";
        var loaderUrl = buildUrl + ""/Drag And Drop.loader.js"";
        var config = {
            dataUrl: buildUrl + ""/Drag And Drop.data"",
            frameworkUrl: buildUrl + ""/Drag And Drop.framework.js"",
            codeUrl: buildUrl + ""/Drag And Drop.wasm"",
            streamingAssetsUrl: ""StreamingAssets"",
            companyName: ""DefaultCompany"",
            productName: ""Drag And Drop"",
            productVersion: ""1.0"",
            showBanner: unityShowBanner,
        };

        // By default Unity keeps WebGL canvas render target size matched with
        // the DOM size of the canvas element (scaled by window.devicePixelRatio)
        // Set this to false if you want ");
            WriteLiteral(@"to decouple this synchronization from
        // happening inside the engine, and you would instead like to size up
        // the canvas DOM size and WebGL render target sizes yourself.
        // config.matchWebGLToCanvasSize = false;

        if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
            // Mobile device style: fill the whole browser client area with the game canvas:

            var meta = document.createElement('meta');
            meta.name = 'viewport';
            meta.content = 'width=device-width, height=device-height, initial-scale=1.0, user-scalable=no, shrink-to-fit=yes';
            document.getElementsByTagName('head')[0].appendChild(meta);
            container.className = ""unity-mobile"";

            // To lower canvas resolution on mobile devices to gain some
            // performance, uncomment the following line:
            // config.devicePixelRatio = 1;

            canvas.style.width = window.innerWidth + 'px';
            canvas.style.height = window.innerH");
            WriteLiteral(@"eight + 'px';

            unityShowBanner('WebGL builds are not supported on mobile devices.');
        } else {
            // Desktop style: Render the game canvas in a window that can be maximized to fullscreen:

            canvas.style.width = ""960px"";
            canvas.style.height = ""600px"";
        }

        loadingBar.style.display = ""block"";

        var script = document.createElement(""script"");
        script.src = loaderUrl;
        script.onload = () => {
            createUnityInstance(canvas, config, (progress) => {
                progressBarFull.style.width = 100 * progress + ""%"";
            }).then((unityInstance) => {
                loadingBar.style.display = ""none"";
                fullscreenButton.onclick = () => {
                    unityInstance.SetFullscreen(1);
                };
            }).catch((message) => {
                alert(message);
            });
        };
        document.body.appendChild(script);
    </script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
