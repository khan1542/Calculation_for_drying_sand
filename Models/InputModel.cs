using System;

namespace Calculation_for_drying_sand.Models
{
    public class InputModel
    {
        #region ����������

        public double C { get; set; }
        public double H { get; set; }
        public double S { get; set; }
        public double O { get; set; }
        public double N { get; set; }
        public double W { get; set; }
        public double Tenv { get; set; }
        public double W0 { get; set; }
        public double W1 { get; set; }
        public double Tmin { get; set; }
        public double Tmstart { get; set; }
        public double D { get; set; }
        public double L { get; set; }
        public double Tmax { get; set; }
        #endregion

        #region �������
        public double QN { get; set; }
        public double If { get; set; }
        public double Iv { get; set; }
        public double Xv { get; set; }
        public double W0c { get; set; }
        public double W1c { get; set; }
        public double Tavg { get; set; }
        public double Q1 { get; set; }
        public double Q2 { get; set; }
        public double Q3 { get; set; }
        public double Q4 { get; set; }
        public double Q5 { get; set; }
        public double Fb { get; set; }
        public double Twavg { get; set; }
        public double Twstart { get; set; }
        public double Twend { get; set; }
        public double AlfaV { get; set; }
        public double B { get; set; }
        public double B1 { get; set; }
        public double Balance { get; set; }
        public double RateB { get; set; }
        public double Qx { get; set; }
        public double Qeva { get; set; }
        public double Total { get; set; }
        public double PQ1 { get; set; }
        public double PQ2 { get; set; }
        public double PQ3 { get; set; }
        public double PQ4 { get; set; }
        public double PQ5 { get; set; }
        public double TotalP { get; set; }
        public double Q2B { get; set; }
        public double Q3B { get; set; }
        public double Q4B { get; set; }

        #endregion

        public void Calculate()
        {
            #region ������ ������� �������

            QN = 340 * C + 1030 * H + 109 * (O - S) - 25 * W;  //������� �������� ������
            #endregion

            #region ������������� � ���������������� ������

            If = 0.9 * 3018.7; // ��������� ������
            Iv = 1.29 * Tenv; // ��������� ������� 
            Xv = (If - 1281) / (1281 - Iv); // ���������� ������� � t=20�C ��� ����������� ��������� ��������
            #endregion

            #region �������� ������

            W0c = W0 / (1 - 0.01 * W0); // ��������� ����� � ����������� �� ����� ����� 10%
            W1c = W1 / (1 - 0.01 * W1); // ��������� ����� � ����������� �� ����� ����� 5%
            Tavg = Tmin - 150; // ������� �� ����� ����������� ����� � ����� �����
            Q1 = ((0.84 + 0.01 * W1c * 4.19) * (Tavg - Tmstart) +
                0.01 * (W0c - W1c) * ((2675 - 4.19 * 20 + 2.102 * (Tmin - 100)))) * 1.75; //������ ������� �� ���������� ������������� ���������� � ��������� �����
            Q2 = (508 + Xv * (463 - Iv)) * 13.178; // ������ ������� � ���������� ������
            Q3 = 0.02 * QN; // ������ ������� � ���������� ���������
            Q4 = (1 - 0.9) * QN; // ������ ������� ������ 
            Twstart = 0.5 * (Tmax + Tmstart);//* ����������� ������ ������� ��������
            Twend = 0.5 * (Tmin + Tavg);//* ����������� ������ � ����� ��������
            Twavg = 0.5 * (Twstart + Twend);//* ������� ����������� ������������� ������ ��������
            AlfaV = 8 + 0.06 * Twavg; // ���������� ����������� �� ����������� ������ �������� � ���. �����
            Q5 = 0.001 * AlfaV * (Twavg - Tenv) * 22.6; //* ������ ������� ���������� ���������������� ������
            Fb = Math.PI * D * L; // ����������� ��������
            B = (Q1 + Q5) / (QN - Q2 - Q3 - Q4); // ������ ������ �� ���� (��/�)
            B1 = ((Q1 + Q5) / (QN - Q2 - Q3 - Q4)) * 3600; // ������ ������ �� ���� (��/�)
            Qx = QN * B; // �������� ���� ����
            Qeva = Qx / (0.01 * (W0c - W1c) * 1.75); // ������ ������� �� 1 �� ���������� �����
            Total = Q1 + Q2 * B + Q3 * B + Q4 * B + Q5; // ����� ������
            Q2B = Q2 * B;
            Q3B = Q3 * B;
            Q4B = Q4 * B;
            // ���� ������� %
            PQ1 = Q1 * 100 / Total;
            PQ2 = Q2B * 100 / Total;
            PQ3 = Q3B * 100 / Total;
            PQ4 = Q4B * 100 / Total;
            PQ5 = Q5 * 100 / Total;
            TotalP = PQ1 + PQ2 + PQ3 + PQ4 + PQ5; // ����� %
            #endregion

        }
        public ResultModel Result()
        {
            return new ResultModel
            {
                B1_ = Math.Round(B1, 2),
                Qx_ = Math.Round(Qx, 2),
                Qeva_ = Math.Round(Qeva, 2),
                QN_ = Math.Round(QN, 2),
                Q1_ = Math.Round(Q1, 2),
                Q2B_ = Math.Round(Q2B, 2),
                Q3B_ = Math.Round(Q3B, 2),
                Q4B_ = Math.Round(Q4B, 2),
                Q5_ = Math.Round(Q5, 2),
                PQ1_ = Math.Round(PQ1, 1),
                PQ2_ = Math.Round(PQ2, 1),
                PQ3_ = Math.Round(PQ3, 1),
                PQ4_ = Math.Round(PQ4, 1),
                PQ5_ = Math.Round(PQ5, 1),
                Total_ = Math.Round(Total, 2),
                TotalP_ = Math.Round(TotalP, 1),
                Efficiency_ = Math.Round(PQ1, 1),
            };
        }
    }
}

