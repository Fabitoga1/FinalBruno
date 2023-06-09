// Copyright 2022 Niantic, Inc. All Rights Reserved.
using UnityEngine;

namespace Niantic.ARDK.Rendering
{
  public static class PropertyBindings
  {
    /// Texture property for the full AR image
    public static readonly int FullImage = Shader.PropertyToID("_texture");

    /// Texture property for the luma component of the AR image
    public static readonly int YChannel = Shader.PropertyToID("_textureY");

    /// Texture property for the chroma components of the AR image
    public static readonly int CbCrChannel = Shader.PropertyToID("_textureCbCr");

    /// Texture property for the depth network output
    public static readonly int DepthChannel = Shader.PropertyToID("_textureDepth");

    /// Texture property for the semantic segmentation network output
    public static readonly int SemanticChannel = Shader.PropertyToID("_textureSemantic");

    // Texture property for depth captured from the fused mesh
    public static readonly int FusedDepthChannel = Shader.PropertyToID("_textureFusedDepth");

    /// Texture property for the depth suppression mask
    public static readonly int DepthSuppressionMask = Shader.PropertyToID("_textureDepthSuppressionMask");

    /// Affine transform to fit the AR image on the viewport
    public static readonly int DisplayTransform = Shader.PropertyToID("_displayTransform");

    /// Affine transform to fit the depth channel on the viewport
    public static readonly int DepthTransform = Shader.PropertyToID("_depthTransform");

    /// Affine transform to fit the semantic channels on the viewport
    public static readonly int SemanticsTransform = Shader.PropertyToID("_semanticsTransform");

    /// The minimum value of the depth interval used for scaling
    public static readonly int DepthScaleMin = Shader.PropertyToID("_depthScaleMin");

    /// The maximum value of the depth interval used for scaling
    public static readonly int DepthScaleMax = Shader.PropertyToID("_depthScaleMax");

    /// Color mask to visualize components of the screen space occluder mesh (if used)
    public static readonly int DebugColorMask = Shader.PropertyToID("_colorMask");

    /// Similar to the built-in _ZBufferParams, but instead of using clipping planes from
    /// the projection, it uses the value range from the depth buffer
    public static readonly int DepthBufferParams = Shader.PropertyToID("_DepthBufferParams");
  }

  public static class FeatureBindings
  {
    /// Refers to the render feature of writing depth directly to the z-buffer
    public const string DepthZWrite = "DEPTH_ZWRITE";

    /// Refers to the render feature of writing depth data to the screen backbuffer
    public const string DepthDebug = "DEPTH_DEBUG";

    /// When enabled, the shader will expect non-linear values in the depth texture
    public const string DepthCompression = "DEPTH_COMPRESSION";

    /// When enabled, parts of the depth texture defined by a semantic mask get discarded
    public const string DepthSuppression = "DEPTH_SUPPRESSION";

    // When enabled, parts of the depth texture get substituted with values from the fused
    // depth render
    public const string DepthStabilization = "DEPTH_STABILIZATION";
  }
}
