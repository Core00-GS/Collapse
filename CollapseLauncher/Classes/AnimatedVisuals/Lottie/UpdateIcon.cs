﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//       LottieGen version:
//           8.0.280225.1+7cd366a738
//       
//       Command:
//           LottieGen -Language CSharp -Namespace CollapseLauncher.AnimatedVisuals.Lottie -Public -WinUIVersion 3.0 -InputFile UpdateIcon.lottie
//       
//       Input file:
//           UpdateIcon.lottie (1532 bytes created 20:12+07:00 Jun 2 2024)
//       
//       LottieGen source:
//           http://aka.ms/Lottie
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// ____________________________________
// |       Object stats       | Count |
// |__________________________|_______|
// | All CompositionObjects   |    42 |
// |--------------------------+-------|
// | Expression animators     |     1 |
// | KeyFrame animators       |     3 |
// | Reference parameters     |     1 |
// | Expression operations    |     0 |
// |--------------------------+-------|
// | Animated brushes         |     - |
// | Animated gradient stops  |     - |
// | ExpressionAnimations     |     1 |
// | PathKeyFrameAnimations   |     - |
// |--------------------------+-------|
// | ContainerVisuals         |     3 |
// | ShapeVisuals             |     1 |
// |--------------------------+-------|
// | ContainerShapes          |     - |
// | CompositionSpriteShapes  |     4 |
// |--------------------------+-------|
// | Brushes                  |     1 |
// | Gradient stops           |     - |
// | CompositionVisualSurface |     - |
// ------------------------------------
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.UI.Composition;
using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.UI;

namespace CollapseLauncher.AnimatedVisuals.Lottie
{
    // Name:        UpdateIconMasterComp
    // Frame rate:  60 fps
    // Frame count: 240
    // Duration:    4000.0 mS
    sealed class UpdateIcon
        : Microsoft.UI.Xaml.Controls.IAnimatedVisualSource
        , Microsoft.UI.Xaml.Controls.IAnimatedVisualSource2
    {
        // Animation duration: 4.000 seconds.
        internal const long c_durationTicks = 40000000;

        public Microsoft.UI.Xaml.Controls.IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor)
        {
            object ignored = null;
            return TryCreateAnimatedVisual(compositor, out ignored);
        }

        public Microsoft.UI.Xaml.Controls.IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor, out object diagnostics)
        {
            diagnostics = null;

            var res = 
                new UpdateIcon_AnimatedVisual(
                    compositor
                    );
                res.CreateAnimations();
                return res;
        }

        /// <summary>
        /// Gets the number of frames in the animation.
        /// </summary>
        public double FrameCount => 240d;

        /// <summary>
        /// Gets the frame rate of the animation.
        /// </summary>
        public double Framerate => 60d;

        /// <summary>
        /// Gets the duration of the animation.
        /// </summary>
        public TimeSpan Duration => TimeSpan.FromTicks(40000000);

        /// <summary>
        /// Converts a zero-based frame number to the corresponding progress value denoting the
        /// start of the frame.
        /// </summary>
        public double FrameToProgress(double frameNumber)
        {
            return frameNumber / 240d;
        }

        /// <summary>
        /// Returns a map from marker names to corresponding progress values.
        /// </summary>
        public IReadOnlyDictionary<string, double> Markers =>
            new Dictionary<string, double>
            {
            };

        /// <summary>
        /// Sets the color property with the given name, or does nothing if no such property
        /// exists.
        /// </summary>
        public void SetColorProperty(string propertyName, Color value)
        {
        }

        /// <summary>
        /// Sets the scalar property with the given name, or does nothing if no such property
        /// exists.
        /// </summary>
        public void SetScalarProperty(string propertyName, double value)
        {
        }

        sealed class UpdateIcon_AnimatedVisual
            : Microsoft.UI.Xaml.Controls.IAnimatedVisual
            , Microsoft.UI.Xaml.Controls.IAnimatedVisual2
        {
            const long c_durationTicks = 40000000;
            readonly Color _color = InnerLauncherConfig.IsAppThemeLight ? Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF) : Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
            readonly Compositor _c;
            readonly ExpressionAnimation _reusableExpressionAnimation;
            AnimationController _animationController_0;
            CompositionColorBrush _colorBrush_White;
            CompositionPathGeometry _pathGeometry_2;
            CompositionPathGeometry _pathGeometry_3;
            ContainerVisual _containerVisual_0;
            ContainerVisual _root;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0;
            ScalarKeyFrameAnimation _trimStartScalarAnimation_0_to_0;
            StepEasingFunction _holdThenStepEasingFunction;

            void BindProperty(
                CompositionObject target,
                string animatedPropertyName,
                string expression,
                string referenceParameterName,
                CompositionObject referencedObject)
            {
                _reusableExpressionAnimation.ClearAllParameters();
                _reusableExpressionAnimation.Expression = expression;
                _reusableExpressionAnimation.SetReferenceParameter(referenceParameterName, referencedObject);
                target.StartAnimation(animatedPropertyName, _reusableExpressionAnimation);
            }

            ScalarKeyFrameAnimation CreateScalarKeyFrameAnimation(float initialProgress, float initialValue, CompositionEasingFunction initialEasingFunction)
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(initialProgress, initialValue, initialEasingFunction);
                return result;
            }

            CompositionSpriteShape CreateSpriteShape(CompositionGeometry geometry, Matrix3x2 transformMatrix)
            {
                var result = _c.CreateSpriteShape(geometry);
                result.TransformMatrix = transformMatrix;
                return result;
            }

            AnimationController AnimationController_0()
            {
                if (_animationController_0 != null) { return _animationController_0; }
                var result = _animationController_0 = _c.CreateAnimationController();
                result.Pause();
                BindProperty(_animationController_0, "Progress", "_.Progress", "_", _root);
                return result;
            }

            // - - - - - PreComp layer: UpdateIcon
            // - - - Layer aggregator
            // - -  Offset:<1543, 561>
            CanvasGeometry Geometry_0()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(244.229004F, -121.904999F));
                    builder.AddLine(new Vector2(123.489998F, 207.692993F));
                    builder.AddLine(new Vector2(-206.199997F, 86.7990036F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: UpdateIcon
            // - - - Layer aggregator
            // - -  Offset:<505.5, 1488>
            CanvasGeometry Geometry_1()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-244.242004F, 122.011002F));
                    builder.AddLine(new Vector2(-123.463997F, -207.692993F));
                    builder.AddLine(new Vector2(206.416F, -86.9020004F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: UpdateIcon
            // - - - Layer aggregator
            // - -  Offset:<1024, 1024>
            CanvasGeometry Geometry_2()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(679.075989F, 179.264008F));
                    builder.AddCubicBezier(new Vector2(662.747986F, 241.386993F), new Vector2(638.117981F, 300.13501F), new Vector2(606.447021F, 354.255005F));
                    builder.AddCubicBezier(new Vector2(545.164978F, 458.975006F), new Vector2(457.518005F, 546.366028F), new Vector2(352.628998F, 607.348022F));
                    builder.AddCubicBezier(new Vector2(248.617004F, 667.820007F), new Vector2(127.649002F, 702.322998F), new Vector2(-1.38F, 702.002014F));
                    builder.AddCubicBezier(new Vector2(-128.865005F, 701.684998F), new Vector2(-248.345001F, 667.411011F), new Vector2(-351.277008F, 607.765015F));
                    builder.AddCubicBezier(new Vector2(-457.304993F, 546.325012F), new Vector2(-545.77301F, 457.962006F), new Vector2(-607.341003F, 352.05899F));
                    builder.AddCubicBezier(new Vector2(-621.362F, 327.941986F), new Vector2(-633.987976F, 302.915009F), new Vector2(-645.109009F, 277.088989F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: UpdateIcon
            // - - - Layer aggregator
            // - -  Offset:<1024, 1024>
            CanvasGeometry Geometry_3()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-679.411011F, -177.884995F));
                    builder.AddCubicBezier(new Vector2(-663.359985F, -239.464996F), new Vector2(-639.156006F, -297.743011F), new Vector2(-608.023987F, -351.501007F));
                    builder.AddCubicBezier(new Vector2(-546.632996F, -457.509003F), new Vector2(-458.299988F, -545.942017F), new Vector2(-352.404999F, -607.463013F));
                    builder.AddCubicBezier(new Vector2(-248.436996F, -667.864014F), new Vector2(-127.541F, -702.322998F), new Vector2(1.40600002F, -702.002014F));
                    builder.AddCubicBezier(new Vector2(129.813995F, -701.682007F), new Vector2(250.102005F, -666.913025F), new Vector2(353.537994F, -606.465027F));
                    builder.AddCubicBezier(new Vector2(460.10199F, -544.189026F), new Vector2(548.778015F, -454.656006F), new Vector2(610.018005F, -347.459015F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CompositionColorBrush ColorBrush_White()
            {
                return (_colorBrush_White == null)
                    ? _colorBrush_White = _c.CreateColorBrush(_color)
                    : _colorBrush_White;
            }

            // - - - PreComp layer: UpdateIcon
            // - Layer aggregator
            // Offset:<1543, 561>
            CompositionPathGeometry PathGeometry_0()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_0()));
            }

            // - - - PreComp layer: UpdateIcon
            // - Layer aggregator
            // Offset:<505.5, 1488>
            CompositionPathGeometry PathGeometry_1()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_1()));
            }

            // - - - PreComp layer: UpdateIcon
            // - Layer aggregator
            // Offset:<1024, 1024>
            CompositionPathGeometry PathGeometry_2()
            {
                if (_pathGeometry_2 != null) { return _pathGeometry_2; }
                var result = _pathGeometry_2 = _c.CreatePathGeometry(new CompositionPath(Geometry_2()));
                return result;
            }

            // - - - PreComp layer: UpdateIcon
            // - Layer aggregator
            // Offset:<1024, 1024>
            CompositionPathGeometry PathGeometry_3()
            {
                if (_pathGeometry_3 != null) { return _pathGeometry_3; }
                var result = _pathGeometry_3 = _c.CreatePathGeometry(new CompositionPath(Geometry_3()));
                return result;
            }

            // - - PreComp layer: UpdateIcon
            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_0()
            {
                // Offset:<1543, 561>
                var result = CreateSpriteShape(PathGeometry_0(), new Matrix3x2(1F, 0F, 0F, 1F, 1543F, 561F));;
                result.StrokeBrush = ColorBrush_White();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 128F;
                return result;
            }

            // - - PreComp layer: UpdateIcon
            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_1()
            {
                // Offset:<505.5, 1488>
                var result = CreateSpriteShape(PathGeometry_1(), new Matrix3x2(1F, 0F, 0F, 1F, 505.5F, 1488F));;
                result.StrokeBrush = ColorBrush_White();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 128F;
                return result;
            }

            // - - PreComp layer: UpdateIcon
            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_2()
            {
                // Offset:<1024, 1024>
                var result = CreateSpriteShape(PathGeometry_2(), new Matrix3x2(1F, 0F, 0F, 1F, 1024F, 1024F));;
                result.StrokeBrush = ColorBrush_White();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 128F;
                return result;
            }

            // - - PreComp layer: UpdateIcon
            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_3()
            {
                // Offset:<1024, 1024>
                var result = CreateSpriteShape(PathGeometry_3(), new Matrix3x2(1F, 0F, 0F, 1F, 1024F, 1024F));;
                result.StrokeBrush = ColorBrush_White();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 128F;
                return result;
            }

            // Transforms for UpdateIcon
            ContainerVisual ContainerVisual_0()
            {
                if (_containerVisual_0 != null) { return _containerVisual_0; }
                var result = _containerVisual_0 = _c.CreateContainerVisual();
                result.CenterPoint = new Vector3(1024F, 1024F, 0F);
                result.Offset = new Vector3(176F, 176F, 0F);
                result.Scale = new Vector3(1F, 1F, 0F);
                result.Children.InsertAtTop(ContainerVisual_1());
                return result;
            }

            // PreComp layer: UpdateIcon
            ContainerVisual ContainerVisual_1()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0();
                result.Size = new Vector2(2048F, 2048F);
                // Layer aggregator
                result.Children.InsertAtTop(ShapeVisual_0());
                return result;
            }

            // The root of the composition.
            ContainerVisual Root()
            {
                if (_root != null) { return _root; }
                var result = _root = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Progress", 0F);
                // PreComp layer: UpdateIcon
                result.Children.InsertAtTop(ContainerVisual_0());
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0()
            {
                return (_cubicBezierEasingFunction_0 == null)
                    ? _cubicBezierEasingFunction_0 = _c.CreateCubicBezierEasingFunction(new Vector2(0.333000004F, 0F), new Vector2(0F, 1F))
                    : _cubicBezierEasingFunction_0;
            }

            // - PreComp layer: UpdateIcon
            InsetClip InsetClip_0()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            // PreComp layer: UpdateIcon
            // Rotation
            ScalarKeyFrameAnimation RotationAngleInDegreesScalarAnimation_0_to_2160()
            {
                // Frame 0.
                var result = CreateScalarKeyFrameAnimation(0F, 0F, HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.125F, -65F, CubicBezierEasingFunction_0());
                // Frame 220.
                result.InsertKeyFrame(0.916666687F, 2160F, _c.CreateCubicBezierEasingFunction(new Vector2(0.158000007F, 0F), new Vector2(0.0240000002F, 1F)));
                return result;
            }

            // TrimStart
            ScalarKeyFrameAnimation TrimStartScalarAnimation_0_to_0()
            {
                // Frame 0.
                if (_trimStartScalarAnimation_0_to_0 != null) { return _trimStartScalarAnimation_0_to_0; }
                var result = _trimStartScalarAnimation_0_to_0 = CreateScalarKeyFrameAnimation(0F, 0F, HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.125F, 0.5F, CubicBezierEasingFunction_0());
                // Frame 80.
                result.InsertKeyFrame(0.333333343F, 0F, CubicBezierEasingFunction_0());
                return result;
            }

            // - PreComp layer: UpdateIcon
            // Layer aggregator
            ShapeVisual ShapeVisual_0()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(2048F, 2048F);
                var shapes = result.Shapes;
                // Offset:<1543, 561>
                shapes.Add(SpriteShape_0());
                // Offset:<505.5, 1488>
                shapes.Add(SpriteShape_1());
                // Offset:<1024, 1024>
                shapes.Add(SpriteShape_2());
                // Offset:<1024, 1024>
                shapes.Add(SpriteShape_3());
                return result;
            }

            StepEasingFunction HoldThenStepEasingFunction()
            {
                if (_holdThenStepEasingFunction != null) { return _holdThenStepEasingFunction; }
                var result = _holdThenStepEasingFunction = _c.CreateStepEasingFunction();
                result.IsFinalStepSingleFrame = true;
                return result;
            }

            internal UpdateIcon_AnimatedVisual(
                Compositor compositor
                )
            {
                _c = compositor;
                _reusableExpressionAnimation = compositor.CreateExpressionAnimation();
                Root();
            }

            public Visual RootVisual => _root;
            public TimeSpan Duration => TimeSpan.FromTicks(c_durationTicks);
            public Vector2 Size => new Vector2(2400F, 2400F);
            void IDisposable.Dispose() => _root?.Dispose();

            public void CreateAnimations()
            {
                _pathGeometry_2.StartAnimation("TrimStart", TrimStartScalarAnimation_0_to_0(), AnimationController_0());
                _pathGeometry_3.StartAnimation("TrimStart", TrimStartScalarAnimation_0_to_0(), AnimationController_0());
                _containerVisual_0.StartAnimation("RotationAngleInDegrees", RotationAngleInDegreesScalarAnimation_0_to_2160(), AnimationController_0());
            }

            public void DestroyAnimations()
            {
                _pathGeometry_2.StopAnimation("TrimStart");
                _pathGeometry_3.StopAnimation("TrimStart");
                _containerVisual_0.StopAnimation("RotationAngleInDegrees");
            }

        }
    }
}
