// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-9785-RGB;n:type:ShaderForge.SFN_TexCoord,id:3794,x:31921,y:32584,varname:node_3794,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8230,x:32122,y:32992,varname:node_8230,prsc:2,spu:1,spv:1|UVIN-3794-UVOUT,DIST-1935-OUT;n:type:ShaderForge.SFN_Time,id:6839,x:31678,y:33025,varname:node_6839,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1935,x:31963,y:33091,varname:node_1935,prsc:2|A-6839-T,B-5951-OUT;n:type:ShaderForge.SFN_Slider,id:5951,x:31645,y:33335,ptovrint:False,ptlb:Water Speed,ptin:_WaterSpeed,varname:node_5951,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:-0.2564103,max:10;n:type:ShaderForge.SFN_Tex2d,id:9785,x:32285,y:32835,ptovrint:False,ptlb:node_9785,ptin:_node_9785,varname:node_9785,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3df117a2022baff4180f8c2beb32dc1a,ntxv:0,isnm:False|UVIN-8230-UVOUT;proporder:5951-9785;pass:END;sub:END;*/

Shader "Shader Forge/Kristy_Watershader" {
    Properties {
        _WaterSpeed ("Water Speed", Range(-10, 10)) = -0.2564103
        _node_9785 ("node_9785", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _WaterSpeed;
            uniform sampler2D _node_9785; uniform float4 _node_9785_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_6839 = _Time;
                float2 node_8230 = (i.uv0+(node_6839.g*_WaterSpeed)*float2(1,1));
                float4 _node_9785_var = tex2D(_node_9785,TRANSFORM_TEX(node_8230, _node_9785));
                float3 emissive = _node_9785_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
