PGDMP                          {            vtsDB    15.1    15.1                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    25029    vtsDB    DATABASE     {   CREATE DATABASE "vtsDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE "vtsDB";
                postgres    false            �            1259    25049    doktor_kayit    TABLE     �   CREATE TABLE public.doktor_kayit (
    tc character varying NOT NULL,
    ad character varying,
    soyad character varying,
    cinsiyet character varying,
    telefon character varying,
    email character varying
);
     DROP TABLE public.doktor_kayit;
       public         heap    postgres    false            �            1259    25030    hasta_kayit    TABLE     �  CREATE TABLE public.hasta_kayit (
    sahip_tc character varying NOT NULL,
    adi character varying,
    dogum_tarihi date,
    tur character varying,
    irk character varying,
    cinsiyet character varying,
    rengi character varying,
    agirlik character varying,
    allerji character varying,
    asi_ismi character varying,
    asi_suresi integer,
    asi_adet integer,
    asi_not character varying
);
    DROP TABLE public.hasta_kayit;
       public         heap    postgres    false            �            1259    25042    hasta_sahip_kayit    TABLE     �   CREATE TABLE public.hasta_sahip_kayit (
    tc character varying NOT NULL,
    ad character varying,
    soyad character varying,
    telefon character varying,
    email character varying,
    adres character varying,
    harcama integer DEFAULT 0
);
 %   DROP TABLE public.hasta_sahip_kayit;
       public         heap    postgres    false            �            1259    25066    muhasebe    TABLE     z   CREATE TABLE public.muhasebe (
    kar bigint DEFAULT 0,
    kazanilan bigint DEFAULT 0,
    harcanan bigint DEFAULT 0
);
    DROP TABLE public.muhasebe;
       public         heap    postgres    false            �            1259    25078    randevu    TABLE     �   CREATE TABLE public.randevu (
    randevu_saati character varying,
    randevu_tarihi date,
    randevu_sahibi_tc character varying,
    randevu_doktoru character varying,
    hasta_sahip_ad character varying,
    randevu_id integer NOT NULL
);
    DROP TABLE public.randevu;
       public         heap    postgres    false            �            1259    25083    randevu_randevu_id_seq    SEQUENCE     �   ALTER TABLE public.randevu ALTER COLUMN randevu_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public.randevu_randevu_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    219            �            1259    25056    stok    TABLE     �   CREATE TABLE public.stok (
    urun_kodu character varying NOT NULL,
    urun_adi character varying,
    urun_fiyat integer,
    urun_adet integer,
    urun_son_fiyat bigint
);
    DROP TABLE public.stok;
       public         heap    postgres    false                      0    25049    doktor_kayit 
   TABLE DATA           O   COPY public.doktor_kayit (tc, ad, soyad, cinsiyet, telefon, email) FROM stdin;
    public          postgres    false    216   �                 0    25030    hasta_kayit 
   TABLE DATA           �   COPY public.hasta_kayit (sahip_tc, adi, dogum_tarihi, tur, irk, cinsiyet, rengi, agirlik, allerji, asi_ismi, asi_suresi, asi_adet, asi_not) FROM stdin;
    public          postgres    false    214   �                 0    25042    hasta_sahip_kayit 
   TABLE DATA           Z   COPY public.hasta_sahip_kayit (tc, ad, soyad, telefon, email, adres, harcama) FROM stdin;
    public          postgres    false    215                    0    25066    muhasebe 
   TABLE DATA           <   COPY public.muhasebe (kar, kazanilan, harcanan) FROM stdin;
    public          postgres    false    218   �                 0    25078    randevu 
   TABLE DATA           �   COPY public.randevu (randevu_saati, randevu_tarihi, randevu_sahibi_tc, randevu_doktoru, hasta_sahip_ad, randevu_id) FROM stdin;
    public          postgres    false    219   �                 0    25056    stok 
   TABLE DATA           Z   COPY public.stok (urun_kodu, urun_adi, urun_fiyat, urun_adet, urun_son_fiyat) FROM stdin;
    public          postgres    false    217   K                    0    0    randevu_randevu_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.randevu_randevu_id_seq', 11, true);
          public          postgres    false    220            �           2606    25055    doktor_kayit doktor_kayit_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.doktor_kayit
    ADD CONSTRAINT doktor_kayit_pkey PRIMARY KEY (tc);
 H   ALTER TABLE ONLY public.doktor_kayit DROP CONSTRAINT doktor_kayit_pkey;
       public            postgres    false    216            ~           2606    25048 (   hasta_sahip_kayit hasta_sahip_kayit_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.hasta_sahip_kayit
    ADD CONSTRAINT hasta_sahip_kayit_pkey PRIMARY KEY (tc);
 R   ALTER TABLE ONLY public.hasta_sahip_kayit DROP CONSTRAINT hasta_sahip_kayit_pkey;
       public            postgres    false    215            �           2606    25090    randevu randevu_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.randevu
    ADD CONSTRAINT randevu_pkey PRIMARY KEY (randevu_id);
 >   ALTER TABLE ONLY public.randevu DROP CONSTRAINT randevu_pkey;
       public            postgres    false    219            �           2606    25062    stok stok_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.stok
    ADD CONSTRAINT stok_pkey PRIMARY KEY (urun_kodu);
 8   ALTER TABLE ONLY public.stok DROP CONSTRAINT stok_pkey;
       public            postgres    false    217               �   x�U�1�@E��0F��a�ce�lLl�YV�.���z/w	!������U��B�H.�7�p�M톪���hk)�$U�$��e�}X.�խ��Jf_"�tau�6V��K�P��؉�ȡTM.A�M[��eޚE��"�=�u��H������]�\>S�b�-P��8������.n�,�p�����Sp����UE_�L_�         f  x�M��N�0E痯���g'�����!Uj$CCk�M"7AJ?��]��4�/^��X,ۺ>G�:�Ru$C�U;��D�G�dea�li�������ޥI
�΂�e~�ظ�a��C�����Q��0�'s>�W��RA|�.��,M\�`[�f�=&��}h��̫���l�&�c��ۆ���|
�V-T��e����eۤ�Xp8F�����d�4�F�����8ګ�C���e<��s�� z��(
�����+�́<"�J�\���fX���4�M��r����G�=5�c��s��q9%�OX&)�u]8��\��UT�3A���>�j�ˑƙ�-YU���ٙm?#�A^F��� T���         �  x�m�Mn�F��5��B��ώ�,؁"Y��)ϴf:l6�MR���D-������^)�J 9^q�|x�}Ue���Z&����S�N�.�;�b-�Ԗ1���44������?�&���4�x�������U�b{Sn2����:�I������v���;n�6pR
y×)4CX�y��@b'�Z�!�)Θ�[>�2�ޅ.�UL��Q����q��\�>�#p�%��z�kŜ�
.)޸C8����(�vJ3㄁���ؐ̐���)����l�ԅ����k�3�XSC�Ӳ�$ż6\j	?�&Lu̷=|����dFI˴��ϫ)��"�S�@{Jb��06�cĮޮ�l*����ېW�MV嬐�Jj>���S�Ӗ 8o��J?4Hh��-�d��2�`���qs�����saL;?�) �S�2�12|���v*/	�~��YE����'xG�U	#S��j�M�3Һ��{����a���V\�v��ZXr☥`
��>zO�it���}!��/�vJw1c���R�>�V���rx������	��[��8Q43����A3-U���H�v��H�<ܵ�$�1!��\K.�B���ȘV�Gc���\�f�9C���f|uѧ�Ud�����X#�5~	��D����Xǵ�9Ʋ���}	d-pTۯd�:���T�.��GUFH�������}xl��>�w�s���!Dg���h�0����+,�-hi�Q�	e�x*r�;�
����m��%�q���D��&��B>?Б)o�;ofA�|"��b�o��~�Y%�r���UaM��D�@�b�w�s���o�\A���B�9nbwp>
-��VrGpC�j��T/��r߳a��36��KKi�Ҽ�ZqZcg��e�����}��l6���$u��kw�
�����?�n�/            x��53�05�416��47020����� 2,�         a   x�3��26�4202�50�52�45227460�42�t�<:?��71#3/��Ӓ����B�������������Ă32���#�8C���8�b���� Q��         �  x�}SMO�0>��>�2u�۱�Ж	F��ih���K� 'ac?d�w-N�5����:�MJE���}>^.D*�0�%箠;�&��\�E�����,t����=tW����� �ƙH5K�f޽��&����/]M�����g�l�p��J�$�]_�t�k:u�M��cCG~��҂dHAvSf���jz�kC���O��\��?M�e{�#�۟l\�Lك2mGu<�=�r��L�X�yI��G:�-��������v�L�:�#	7"�=t���a�f���;3+:�UPe��/7�l�Hi@�J�����ЮnF����#׬4�(�,tXN0eT��0*����۠����A���R.t*`�����=�fy{��M]���TB
J["$�1͸ᰗ�'���_��m@o�w�r��zB�D�����;�L�R��q�q2�����*t��FG�C1qC9l����yx'�{��V�=�����Έ�L�U�	c�3ь�kc�|>6|=@��k���A����:��O�tg0�Tp{��S�F1c�%T�&�N�6���� �k��X�X�+�tR޸kR���-�/良c��X�����q�`r�S����"��hG1|F�Q�k�lU��u2¢jk�C�9U�`S���`y� F/K>�!��|a8     