Shader "Water Is Flowing"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    
        _WaveAmp ("Wave Amplitude", Float) = .5
        _WaveFrequency ("Wave Frequency", Float) = .1

        _ReflectionSpeed ("Reflection Speed", Float) = .03
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _WaveAmp;
            float _WaveFrequency;
            float _ReflectionSpeed;

            // VERTEX FUNCTION
            v2f vert (appdata v)
            {
                v2f o;

                // TIME TO MOVE SOME VERTICIES
                v.vertex += float4 (
                    0,
                    sin((_Time.y + v.vertex.x + v.vertex.z) * _WaveFrequency) * _WaveAmp,
                    0,
                    0);
                

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            // FRAGMENT  --  PUTTING IT ALL TOGETHER

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                // OFFSET THE TEXTURE W TIME-BASED UPDATE CALLS
                fixed4 col = tex2D(_MainTex, i.uv + float2(_Time.x, _Time.y) * _ReflectionSpeed);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
