using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using OpenSkinDesigner.Logic;

namespace OpenSkinDesigner.Structures
{
    class sGraphicListbox : sGraphicElement
    {
        //protected sAttributeListbox pAttr;

        public sGraphicListbox(sAttributeListbox attr)
            : base(attr)
        {
            pAttr = attr;
        }

        public override void paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!pAttr.pTransparent)
            {
                //Background
                Int32 tx = (Int32)pAttr.pAbsolutX;
                Int32 ty = (Int32)pAttr.pAbsolutY;
                Int32 tw = (Int32)pAttr.pWidth;
                Int32 th = (Int32)pAttr.pHeight;

                if (((sAttributeListbox)pAttr).pBackgroundPixmap != null)
                    new sGraphicImage(pAttr, ((sAttributeListbox)pAttr).pBackgroundPixmapName).paint(sender, e);
                else
                    new sGraphicRectangel((Int32)(tx > 0 ? tx : 0), (Int32)(ty > 0 ? ty : 0), (Int32)(tw > 0 ? tw : 0), (Int32)(th > 0 ? th : 0), true, (float)1.0, ((sAttributeListbox)pAttr).pListboxBackgroundColor).paint(sender, e);
            }

            //BorderLayout
            Int32 x = pAttr.pAbsolutX, xm = pAttr.pAbsolutX + pAttr.pWidth;

            if (((sAttributeListbox)pAttr).pbpTopLeftName != null)
            {
                new sGraphicImage(pAttr,
                    ((sAttributeListbox)pAttr).pbpTopLeftName,
                    x - (Int32)(((sAttributeListbox)pAttr).pbpLeft != null ? ((sAttributeListbox)pAttr).pbpLeft.Width : 0),
                    pAttr.pAbsolutY - (Int32)((sAttributeListbox)pAttr).pbpTopLeft.Height
                    ).paint(sender, e);
                //painter.blit(tl, ePoint(x, pos.top()));
                //x += (UInt32)pAttr.pbpTopLeft.Width;
            }

            if (((sAttributeListbox)pAttr).pbpTopRightName != null)
            {
                //xm -= (UInt32)pAttr.pbpTopRight.Width;
                new sGraphicImage(pAttr,
                    ((sAttributeListbox)pAttr).pbpTopRightName,
                    xm + (Int32)(((sAttributeListbox)pAttr).pbpRight != null ? ((sAttributeListbox)pAttr).pbpRight.Width : 0) - (Int32)((sAttributeListbox)pAttr).pbpTopRight.Width,
                    pAttr.pAbsolutY - (Int32)((sAttributeListbox)pAttr).pbpTopRight.Height
                    ).paint(sender, e);
                //painter.blit(tr, ePoint(xm, pos.top()), pos);
            }

            if (((sAttributeListbox)pAttr).pbpTopName != null)
            {
                x += (Int32)(((sAttributeListbox)pAttr).pbpTopLeft != null ? ((sAttributeListbox)pAttr).pbpTopLeft.Width : 0) - (Int32)(((sAttributeListbox)pAttr).pbpLeft != null ? ((sAttributeListbox)pAttr).pbpLeft.Width : 0);
                int diff = (((sAttributeListbox)pAttr).pbpRight != null ? ((sAttributeListbox)pAttr).pbpRight.Width : 0) - (((sAttributeListbox)pAttr).pbpTopRight != null ? ((sAttributeListbox)pAttr).pbpTopRight.Width : 0);
                xm -= (Int32)(diff > 0 ? diff : -diff);
                while (x < xm)
                {
                    new sGraphicImage(pAttr,
                        ((sAttributeListbox)pAttr).pbpTopName,
                        x,
                        pAttr.pAbsolutY - (Int32)((sAttributeListbox)pAttr).pbpTop.Height,
                        xm - x,
                        (Int32)((sAttributeListbox)pAttr).pbpTop.Height
                        ).paint(sender, e);
                    //painter.blit(t, ePoint(x, pos.top()), eRect(x, pos.top(), xm - x, pos.height()));
                    x += (Int32)((sAttributeListbox)pAttr).pbpTop.Width;
                }
            }

            x = pAttr.pAbsolutX;
            xm = pAttr.pAbsolutX + pAttr.pWidth;

            if (((sAttributeListbox)pAttr).pbpBottomLeftName != null)
            {
                new sGraphicImage(pAttr,
                    ((sAttributeListbox)pAttr).pbpBottomLeftName,
                    x - (Int32)(((sAttributeListbox)pAttr).pbpLeft != null ? ((sAttributeListbox)pAttr).pbpLeft.Width : 0),
                    pAttr.pAbsolutY + pAttr.pHeight
                    ).paint(sender, e);
                //painter.blit(bl, ePoint(pos.left(), pos.bottom()-bl->size().height()));
                //x += (UInt32)pAttr.pbpBottomLeft.Width;
            }

            if (((sAttributeListbox)pAttr).pbpBottomRightName != null)
            {
                //xm -= (UInt32)pAttr.pbpBottomRight.Width;
                new sGraphicImage(pAttr,
                    ((sAttributeListbox)pAttr).pbpBottomRightName,
                    xm + (Int32)(((sAttributeListbox)pAttr).pbpRight != null ? ((sAttributeListbox)pAttr).pbpRight.Width : 0) - (Int32)((sAttributeListbox)pAttr).pbpBottomRight.Width,
                    pAttr.pAbsolutY + pAttr.pHeight
                    ).paint(sender, e);
                //painter.blit(br, ePoint(xm, pos.bottom()-br->size().height()), eRect(x, pos.bottom()-br->size().height(), pos.width() - x, bl->size().height()));
            }

            if (((sAttributeListbox)pAttr).pbpBottomName != null)
            {
                x += (Int32)(((sAttributeListbox)pAttr).pbpBottomLeft != null ? ((sAttributeListbox)pAttr).pbpBottomLeft.Width : 0) - (Int32)(((sAttributeListbox)pAttr).pbpLeft != null ? ((sAttributeListbox)pAttr).pbpLeft.Width : 0);
                int diff = (((sAttributeListbox)pAttr).pbpRight != null ? ((sAttributeListbox)pAttr).pbpRight.Width : 0) - (((sAttributeListbox)pAttr).pbpBottomRight != null ? ((sAttributeListbox)pAttr).pbpBottomRight.Width : 0);
                xm -= (Int32)(diff > 0 ? diff : -diff);
                while (x < xm)
                {
                    new sGraphicImage(pAttr,
                        ((sAttributeListbox)pAttr).pbpBottomName,
                        x,
                        pAttr.pAbsolutY + pAttr.pHeight,
                        xm - x,
                        (Int32)((sAttributeListbox)pAttr).pbpBottom.Height
                        ).paint(sender, e);
                    //painter.blit(b, ePoint(x, pos.bottom()-b->size().height()), eRect(x, pos.bottom()-b->size().height(), xm - x, pos.height()));
                    x += (Int32)((sAttributeListbox)pAttr).pbpBottom.Width;
                }
            }

            Int32 y = 0;
            //if (pAttr.pbpTopLeft != null)
            //    y = (UInt32)pAttr.pbpTopLeft.Height;

            y += pAttr.pAbsolutY;

            Int32 ym = pAttr.pAbsolutY + pAttr.pHeight;
            //if (pAttr.pbpBottomLeft != null)
            //    ym -= (UInt32)pAttr.pbpBottomLeft.Height;

            if (((sAttributeListbox)pAttr).pbpLeftName != null)
            {
                while (y < ym)
                {
                    new sGraphicImage(pAttr,
                        ((sAttributeListbox)pAttr).pbpLeftName,
                        pAttr.pAbsolutX - (Int32)((sAttributeListbox)pAttr).pbpLeft.Width,
                        y,
                        (Int32)((sAttributeListbox)pAttr).pbpLeft.Width,
                        ym - y
                        ).paint(sender, e);
                    //painter.blit(l, ePoint(pos.left(), y), eRect(pos.left(), y, pos.width(), ym - y));
                    y += (Int32)((sAttributeListbox)pAttr).pbpLeft.Height;
                }
            }

            y = 0;

            //if (pAttr.pbpTopRight != null)
            //    y = (UInt32)pAttr.pbpTopRight.Height;

            y += pAttr.pAbsolutY;

            ym = pAttr.pAbsolutY + pAttr.pHeight;
            //if (pAttr.pbpBottomRight != null)
            //    ym -= (UInt32)pAttr.pbpBottomRight.Height;

            if (((sAttributeListbox)pAttr).pbpRightName != null)
            {
                while (y < ym)
                {
                    new sGraphicImage(pAttr,
                        ((sAttributeListbox)pAttr).pbpRightName,
                        pAttr.pAbsolutX + pAttr.pWidth,
                        y,
                        (Int32)((sAttributeListbox)pAttr).pbpRight.Width,
                        ym - y
                        ).paint(sender, e);
                    //painter.blit(r, ePoint(pos.right() - r->size().width(), y), eRect(pos.right()-r->size().width(), y, r->size().width(), ym - y));
                    y += (Int32)((sAttributeListbox)pAttr).pbpRight.Height;
                }
            }

            // scrollbar
            //painter.clip(eRect(m_scrollbar->position() - ePoint(5, 0), eSize(5, m_scrollbar->size().height())));

            // entries
            if (((sAttributeListbox)pAttr).pPreviewEntries != null)
            {
                if (((sAttributeListbox)pAttr).pPreviewEntries.Length >= 1)
                {
                    int itemHeight = ((sAttributeListbox)pAttr).pItemHeight;
                    sFont font = cDataBase.getFont("Regular");
                    cProperty.eHAlign halign = cProperty.eHAlign.Left;
                    cProperty.eVAlign valign = cProperty.eVAlign.Top;
                    sColor foreground = ((sAttributeListbox)pAttr).pListboxSelectedForegroundColor;
                    sColor background = ((sAttributeListbox)pAttr).pListboxSelectedBackgroundColor;
                    String entry = ((sAttributeListbox)pAttr).pPreviewEntries[0];

                    // Selection Pixmap
                    if (((sAttributeListbox)pAttr).pSelectionPixmapName != null)
                        new sGraphicImage(null, ((sAttributeListbox)pAttr).pSelectionPixmapName, pAttr.pAbsolutX, pAttr.pAbsolutY, pAttr.pWidth, ((sAttributeListbox)pAttr).pItemHeight).paint(sender, e);
                    else
                        new sGraphicRectangel(pAttr.pAbsolutX, pAttr.pAbsolutY, pAttr.pWidth, ((sAttributeListbox)pAttr).pItemHeight, true, 1.0F, ((sAttributeListbox)pAttr).pListboxSelectedBackgroundColor).paint(sender, e);

                    if (pAttr.pTransparent)
                        new sGraphicFont(null, pAttr.pAbsolutX, pAttr.pAbsolutY, entry, 20.0f/*always 20*/, font, foreground, halign, valign).paint(sender, e);
                    else
                        new sGraphicFont(null, pAttr.pAbsolutX, pAttr.pAbsolutY, entry, 20.0f/*always 20*/, font, foreground, background == null ? new sColor(Color.Black) : background, halign, valign).paint(sender, e);

                    if (((sAttributeListbox)pAttr).pPreviewEntries.Length > 1)
                    {
                        foreground = ((sAttributeListbox)pAttr).pListboxForegroundColor;
                        background = ((sAttributeListbox)pAttr).pListboxBackgroundColor;

                        for (int i = 1; i < ((sAttributeListbox)pAttr).pPreviewEntries.Length; i++)
                        {
                            entry = ((sAttributeListbox)pAttr).pPreviewEntries[i];

                            // NonSelection Pixmap
                            if (((sAttributeListbox)pAttr).pBackgroundPixmapName != null)
                                new sGraphicImage(null, ((sAttributeListbox)pAttr).pBackgroundPixmapName, pAttr.pAbsolutX, pAttr.pAbsolutY + i * itemHeight, pAttr.pWidth, ((sAttributeListbox)pAttr).pItemHeight).paint(sender, e);
                            else
                                new sGraphicRectangel(pAttr.pAbsolutX, pAttr.pAbsolutY + i * itemHeight, pAttr.pWidth, ((sAttributeListbox)pAttr).pItemHeight, true, 1.0F, ((sAttributeListbox)pAttr).pListboxBackgroundColor).paint(sender, e);

                            if (pAttr.pTransparent)
                                new sGraphicFont(null, pAttr.pAbsolutX, pAttr.pAbsolutY + i * itemHeight, entry, 20.0f/*always 20*/, font, foreground, halign, valign).paint(sender, e);
                            else
                                new sGraphicFont(null, pAttr.pAbsolutX, pAttr.pAbsolutY + i * itemHeight, entry, 20.0f/*always 20*/, font, foreground, background == null ? new sColor(Color.Black) : background, halign, valign).paint(sender, e);
                        }
                    }
                }
                else
                {
                    // Selection Pixmap
                    if (((sAttributeListbox)pAttr).pSelectionPixmapName != null)
                        new sGraphicImage(pAttr, ((sAttributeListbox)pAttr).pSelectionPixmapName).paint(sender, e);
                    else
                        new sGraphicRectangel(pAttr.pAbsolutX, pAttr.pAbsolutY, pAttr.pWidth, ((sAttributeListbox)pAttr).pItemHeight, true, 1.0F, ((sAttributeListbox)pAttr).pListboxSelectedBackgroundColor).paint(sender, e);
                }
            }
        }
    }
}
