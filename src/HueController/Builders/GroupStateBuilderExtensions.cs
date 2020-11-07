using PReardon.HueController.Lights.Model;

namespace PReardon.HueController.Builders
{
    public static class GroupStateBuilderExtensions
    {
        /// <summary>
        /// Set the Transition time for this command
        /// </summary>
        /// <param name="transitionTime">The duration of the transition from the light’s current state to the new state. This is given as a multiple of 100ms and defaults to 4 (400ms). For example, setting transitiontime:10 will make the transition last 1 second.</param>
        /// <returns></returns>
        public static GroupStateBuilder WithTransitionTime(this GroupStateBuilder builder, int transitionTime)
        {
            builder.GroupState.TransitionTime = transitionTime;
            return builder;
        }
        public static GroupStateBuilder IncrimentBrightness(this GroupStateBuilder builder, int incriment)
        {
            builder.GroupState.IncrimentBrightness = incriment;
            return builder;
        }
        public static GroupStateBuilder IncrimentSaturation(this GroupStateBuilder builder, int incriment)
        {
            builder.GroupState.InsreaseSaturation = incriment;
            return builder;
        }
        public static GroupStateBuilder IncrimentHue(this GroupStateBuilder builder, int incriment)
        {
            builder.GroupState.IncreaseHue = incriment;
            return builder;
        }
        public static GroupStateBuilder IncreaseColourTemperature(this GroupStateBuilder builder, int incriment)
        {
            builder.GroupState.IncreaseColourTemperature = incriment;
            return builder;
        }
        public static GroupStateBuilder IncreaseXY(this GroupStateBuilder builder, double[] incriment)
        {
            builder.GroupState.IncreaseXY = incriment;
            return builder;
        }
        public static GroupStateBuilder TurnOn(this GroupStateBuilder builder)
        {
            builder.GroupState.On = true;
            return builder;
        }
        public static GroupStateBuilder TurnOff(this GroupStateBuilder builder)
        {
            builder.GroupState.On = false;
            return builder;
        }
        public static GroupStateBuilder WithBrightness(this GroupStateBuilder builder, int brightness)
        {
            builder.GroupState.Brightness = brightness;
            return builder;
        }
        public static GroupStateBuilder WithHue(this GroupStateBuilder builder, int hue)
        {
            builder.GroupState.Hue = hue;
            return builder;
        }
        public static GroupStateBuilder WithSaturation(this GroupStateBuilder builder, int saturation)
        {
            builder.GroupState.Saturation = saturation;
            return builder;
        }
        public static GroupStateBuilder WithEffect(this GroupStateBuilder builder, LightStateEffect effect)
        {
            builder.GroupState.Effect = effect;
            return builder;
        }
        public static GroupStateBuilder WithXY(this GroupStateBuilder builder, double[] xy)
        {
            builder.GroupState.XY = xy;
            return builder;
        }
        public static GroupStateBuilder WithColourTemperature(this GroupStateBuilder builder, int colourTemperature)
        {
            builder.GroupState.ColourTemperature = colourTemperature;
            return builder;
        }

    }
}
