Shader "Custom/otline"
{
    Properties
    {
        _Color("Main Color", Color) = (0.5,0.5,0.5,1) 
        _MainTex ("MainTexture(RBG)", 2D) = "white" {}
        _OutLineColor("OutLine Color", Color) = (1,1,1,1) 
        _OutLineWidth("OutLine Width", Range(1.0, 5.0)) = 5
    }
    CGINCLUDE

    #include "UnityCG.cginc" 
    struct appdata
    {
        float4 vertex : Position;
        float3 normal : Normal;
    };


    struct v2f
    {
        float4 pos : Position;
        float3 normal : Normal;
    };


    float _OutLineWidth;
    float4 _OutLineColor;

    v2f vert(appdata v){
        v.vertex.xyz *= _OutLineWidth;
        v2f o ;
        o.pos = UnityObjectToClipPos(v.vertex);
        return o;
    }
    ENDCG    
    

    SubShader
    {
        Tags{"Queue" = "transparent"}
        Pass
        {
            ZWrite off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            half4 frag (v2f i) :Color{
                return _OutLineColor;
            }

            ENDCG
        }
        Pass
        {
            ZWrite on
            Material
            {
                Diffuse[_Color]
                Ambient[_Color]
            }

            Lighting on
            SetTexture[_MainTex]
            {
                ConstantColor[_Color]
            }
            SetTexture[_MainTex]
            {
                Combine previous * primary DOUBLE 
            }
        }
    }
}
