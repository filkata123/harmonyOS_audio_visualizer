// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/BubbleSoftGlass_Builtin2D"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _DistortStrength ("Distort Strength", Float) = 0.1
        _AudioAmplitude ("Audio Amplitude", Float) = 0.0
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        ZTest Always
        Cull Off

        Pass
        {
            Name "BubbleSoftBody"

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _DistortStrength;
            float _AudioAmplitude;

            v2f vert(appdata v)
            {
                v2f o;
                
                float3 pos = v.vertex.xyz;

                // Soft-body radial deformation
                float deform = _AudioAmplitude * _DistortStrength;
                
                // avoid collapsing near center
                if (length(pos.xy) > 0.001)
                    pos.xy += normalize(pos.xy) * deform;

                // Transform to clip space
                o.pos = UnityObjectToClipPos(float4(pos,1.0));
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                return col;
            }

            ENDCG
        }
    }

    Fallback "Unlit/Transparent"
}
