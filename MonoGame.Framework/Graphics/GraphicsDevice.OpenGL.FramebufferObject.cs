﻿// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if MONOMAC
using MonoMac.OpenGL;
#endif

#if OPENGL && !GLES
using OpenTK.Graphics.OpenGL;
#endif

#if GLES
using OpenTK.Graphics.ES20;
#endif

namespace Microsoft.Xna.Framework.Graphics
{
    // ARB_framebuffer_object implementation
    partial class GraphicsDevice
    {
        internal class FramebufferObject
        {
            public virtual void Bind(FramebufferTarget target, int id)
            {
                GL.BindFramebuffer(target, id);
                GraphicsExtensions.CheckGLError();
            }

            public virtual FramebufferErrorCode CheckStatus(FramebufferTarget target)
            {
                return (FramebufferErrorCode)GL.CheckFramebufferStatus(target);
            }

            public virtual void Delete(int id)
            {
                GL.DeleteFramebuffers(1, ref id);
                GraphicsExtensions.CheckGLError();
            }

            public virtual int Generate()
            {
                int id = GL.GenFramebuffer();
                GraphicsExtensions.CheckGLError();
                return id;
            }

            public virtual void Renderbuffer(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbufferTarget, int renderbuffer)
            {
                GL.FramebufferRenderbuffer(target, attachment, renderbufferTarget, renderbuffer);
                GraphicsExtensions.CheckGLError();
            }

            public virtual void Texture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textureTarget, int texture, int level)
            {
                GL.FramebufferTexture2D(target, attachment, textureTarget, texture, level);
                GraphicsExtensions.CheckGLError();
            }
        }

#if !(GLES || MONOMAC)
        // EXT_framebuffer_object implementation
        internal sealed class FramebufferObjectEXT : FramebufferObject
        {
            public override void Bind(FramebufferTarget target, int id)
            {
                GL.Ext.BindFramebuffer(target, id);
                GraphicsExtensions.CheckGLError();
            }

            public override FramebufferErrorCode CheckStatus(FramebufferTarget target)
            {
                return GL.Ext.CheckFramebufferStatus(target);
            }

            public override void Delete(int id)
            {
                GL.Ext.DeleteFramebuffers(1, ref id);
                GraphicsExtensions.CheckGLError();
            }

            public override int Generate()
            {
                int id;
                GL.Ext.GenFramebuffers(1, out id);
                GraphicsExtensions.CheckGLError();
                return id;
            }

            public override void Renderbuffer(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbufferTarget, int renderbuffer)
            {
                GL.Ext.FramebufferRenderbuffer(target, attachment, renderbufferTarget, renderbuffer);
                GraphicsExtensions.CheckGLError();
            }

            public override void Texture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textureTarget, int texture, int level)
            {
                GL.Ext.FramebufferTexture2D(target, attachment, textureTarget, texture, level);
                GraphicsExtensions.CheckGLError();
            }
        }
#endif
    }
}
