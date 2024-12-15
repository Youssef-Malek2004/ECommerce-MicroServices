export interface GetProductByIdProductDto {
  id: string;
  name: string;
  description: string;
  createdAt: string;
  updatedAt: string;
  categoryId: string;
  vendorId: string;
  imageUrls: string[];
  tags: string[];
  sku: string;
  price: number;
  isDeleted: boolean;
  featured: boolean;
  material?: string;
  finish?: string;
  length?: number;
  width?: number;
  height?: number;
  weight?: number;
  color?: string;
  subCategory?: string;
  usage?: string;
  isCustomizable?: boolean;
  features?: string;
  warrantyInYears?: number;
  maintenanceInstructions?: string;
  brand?: string;
  manufacturer?: string;
  manufactureDate?: string;
  countryOfOrigin?: string;
  isEcoFriendly?: boolean;
}