Shader "Custom/Dissolve" {

    Properties{
        _MainColor("Main Color", Color) = (1,1,1,1) // ���f���̐F
        _MainTex("Base (RGB)", 2D) = "white" {}     // ���f���̃e�N�X�`���[
        _Mask("Mask To Dissolve", 2D) = "white" {}  // ����p�̃}�X�N
        _CutOff("CutOff Range", Range(0,1)) = 0     // �����̂������l
        _Width("Width", Range(0,1)) = 0.001         // �������l�̕�
        _ColorIntensity("Intensity", Float) = 1     // �R���s���镔���̖��邳�̋��x�iBloom+HDR���g��Ȃ��ꍇ�͕s�v�j
        _Color("Line Color", Color) = (1,1,1,1)     // �R���s���镔���̐F
        _BumpMap("Normalmap", 2D) = "bump" {}       // ���f���̃o���v�}�b�s���O
    }

        SubShader{

            Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
            LOD 300

        // ���f���̕`�揇�����������Ȃ���̑Ώ�
        Pass{
            ZWrite On
            ColorMask 0
        }

        CGPROGRAM
        #pragma target 2.0
        #include "UnityCG.cginc"
        #pragma surface surf Lambert alpha 

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _Mask;
        fixed4 _Color;
        fixed4 _MainColor;
        fixed _CutOff;
        fixed _Width;
        fixed _ColorIntensity;

        struct Input {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        void surf(Input IN, inout SurfaceOutput o) {

            // �e�N�X�`���̐F���擾
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex) * _MainColor;
            // �o���v�}�b�s���O
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

            // �}�X�N�p�e�N�X�`������Z�x���擾�i���m�N���Ȃ̂Őԃ`�����l���̒l�����g�p����j
            fixed a = tex2D(_Mask, IN.uv_MainTex).r;

            // �R����؂�[�\���ia�̒l���A�������l�`�������l�{���͈̔͂�0�`1�Ƃ��Ċۂ߂�j
            fixed b = smoothstep(_CutOff, _CutOff + _Width, a);
            o.Emission = _Color * b * _ColorIntensity;

            // ��������͈͂����߂�@(_CutOff + _Width * 2.0 >= a) ? 1 : 0
            fixed b2 = step(a, _CutOff + _Width * 2.0);
            o.Alpha = b2;
        }
        ENDCG
    }
        Fallback "Diffuse"
}