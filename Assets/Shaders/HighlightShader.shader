Shader "Custom/TerrainHighlight"{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _MainColor("Main Color", Color) = (0,1,0)
        _CircleColor("CircleColor", Color) = (1,0,0)
        _Center("Center", Vector) = (0,0,0,0)
        _Radius("Radius", Range(0,100)) = 10
    }
        SubShader{
            CGPROGRAM
            #pragma surface surfaceFunc Lambert

            sampler2D _MainTex;
            fixed3 _MainColor;
            fixed3 _CircleColor;
            float3 _Center;
            float _Radius;

            struct Input{
                float2 uv_MainTex;
                float3 worldPos;
            };

            void surfaceFunc(Input In, inout SurfaceOutput o){
                half4 c = tex2D(_MainTex, In.uv_MainTex);
                float d = distance(_Center, In.worldPos);

                if(d < _Radius){
                    o.Albedo = _CircleColor;
                }
                else{
                    o.Albedo = c.rgb;
                }
                o.Alpha = c.a;
            }
            ENDCG
        }
}