(function(window){var svgSprite="<svg>"+""+'<symbol id="icon-yishengpaiban" viewBox="0 0 1024 1024">'+""+'<path d="M929.792 140.8c8.704 0 16.896 8.704 16.896 16.896v769.536c0 8.704-8.704 16.896-16.896 16.896H94.208c-8.704 0-16.896-8.704-16.896-16.896V158.208c0-8.704 8.704-16.896 16.896-16.896h835.584v-0.512z m0-51.2H94.208C56.32 89.6 25.6 120.32 25.6 158.208v769.536c0 37.376 30.72 68.608 68.608 68.608h836.096c37.376 0 68.608-30.72 68.608-68.608V158.208c-0.512-37.888-31.232-68.608-69.12-68.608" fill="#333333" ></path>'+""+'<path d="M237.568 207.872c-13.824 0-25.6-11.776-25.6-25.6v-128c0-13.824 11.776-25.6 25.6-25.6s25.6 11.776 25.6 25.6v128c0 13.312-10.24 25.6-25.6 25.6z m528.384 0c-13.824 0-25.6-11.776-25.6-25.6v-128c0-13.824 11.776-25.6 25.6-25.6s25.6 11.776 25.6 25.6v128c0 13.312-11.776 25.6-25.6 25.6zM957.44 347.648H51.2c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h906.24c13.824 0 25.6 11.776 25.6 25.6s-11.776 25.6-25.6 25.6zM293.888 476.16h-138.24c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h138.24c13.824 0 25.6 11.776 25.6 25.6s-11.776 25.6-25.6 25.6z m302.592 0h-138.24c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h138.24c13.824 0 25.6 11.776 25.6 25.6s-10.24 25.6-25.6 25.6z m280.576 0h-128c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h128c13.824 0 25.6 11.776 25.6 25.6s-11.776 25.6-25.6 25.6zM293.888 664.064h-138.24c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h138.24c13.824 0 25.6 11.776 25.6 25.6s-11.776 25.6-25.6 25.6z m302.592 0h-138.24c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h138.24c13.824 0 25.6 11.776 25.6 25.6s-10.24 25.6-25.6 25.6z m280.576 0h-128c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h128c13.824 0 25.6 11.776 25.6 25.6s-11.776 25.6-25.6 25.6zM293.888 869.376h-138.24c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h138.24c13.824 0 25.6 11.776 25.6 25.6s-11.776 25.6-25.6 25.6z m302.592 0h-138.24c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h138.24c13.824 0 25.6 11.776 25.6 25.6s-10.24 25.6-25.6 25.6z m280.576 0h-128c-13.824 0-25.6-11.776-25.6-25.6s11.776-25.6 25.6-25.6h128c13.824 0 25.6 11.776 25.6 25.6s-11.776 25.6-25.6 25.6z" fill="#333333" ></path>'+""+"</symbol>"+""+"</svg>";var script=function(){var scripts=document.getElementsByTagName("script");return scripts[scripts.length-1]}();var shouldInjectCss=script.getAttribute("data-injectcss");var ready=function(fn){if(document.addEventListener){if(~["complete","loaded","interactive"].indexOf(document.readyState)){setTimeout(fn,0)}else{var loadFn=function(){document.removeEventListener("DOMContentLoaded",loadFn,false);fn()};document.addEventListener("DOMContentLoaded",loadFn,false)}}else if(document.attachEvent){IEContentLoaded(window,fn)}function IEContentLoaded(w,fn){var d=w.document,done=false,init=function(){if(!done){done=true;fn()}};var polling=function(){try{d.documentElement.doScroll("left")}catch(e){setTimeout(polling,50);return}init()};polling();d.onreadystatechange=function(){if(d.readyState=="complete"){d.onreadystatechange=null;init()}}}};var before=function(el,target){target.parentNode.insertBefore(el,target)};var prepend=function(el,target){if(target.firstChild){before(el,target.firstChild)}else{target.appendChild(el)}};function appendSvg(){var div,svg;div=document.createElement("div");div.innerHTML=svgSprite;svgSprite=null;svg=div.getElementsByTagName("svg")[0];if(svg){svg.setAttribute("aria-hidden","true");svg.style.position="absolute";svg.style.width=0;svg.style.height=0;svg.style.overflow="hidden";prepend(svg,document.body)}}if(shouldInjectCss&&!window.__iconfont__svg__cssinject__){window.__iconfont__svg__cssinject__=true;try{document.write("<style>.svgfont {display: inline-block;width: 1em;height: 1em;fill: currentColor;vertical-align: -0.1em;font-size:16px;}</style>")}catch(e){console&&console.log(e)}}ready(appendSvg)})(window)